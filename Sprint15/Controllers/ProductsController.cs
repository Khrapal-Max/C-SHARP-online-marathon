using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProductsValidation.Models;
using ProductsValidation.Services;

namespace ProductsValidation.Controllers
{

    public class ProductsController : Controller
    {
        private List<Product> myProducts;

        public ProductsController(Data data)
        {
            myProducts = data.Products;
        }

        public IActionResult Index(int filterId, string filtername)
        {
            return View(myProducts);
        }

        public IActionResult View(int id)
        {
            Product prod = myProducts.Find(prod => prod.Id == id);
            if (prod != null)
            {
                return View(prod);
            }

            return View("NotExists");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product prod = myProducts.Find(prod => prod.Id == id);
            if (prod != null)
            {
                return View(prod);
            }

            return View("NotExists");
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            myProducts[myProducts.FindIndex(prod => prod.Id == product.Id)] = product;
            return View("View", product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            myProducts.Add(product);
            return View("View", product);
        }

        public IActionResult Create()
        {
            return View(new Product() { Id = myProducts.Last().Id + 1 });
        }

        public IActionResult Delete(int id)
        {
            myProducts.Remove(myProducts.Find(product => product.Id == id));
            return View("Index", myProducts);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult EditPriceForAllCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditPriceForAllCategory(Product.Category type)
        {
            var selectedCategory = myProducts.Where(x => x.Type == type);
            return View("ChangePriceCategory", selectedCategory);
        }

        public IActionResult ChangePriceCategory(Product[] products)
        {
            for (int i = 0; i < products.Length; i++)
            {
                for (int j = 0; j < myProducts.Count(); j++)
                {
                    if (products[i].Id == myProducts[j].Id)
                        myProducts[j].Price = products[i].Price;
                }
            }

            return View("Index", myProducts);
        }

        /// <summary>
        /// Этот метод проверяет заполнение поля Category для класса Product
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public JsonResult ValidateCategoryProduct(Product.Category type)
        {
            if (type == Product.Category.Select)
                return Json("Category must be select");
            else
                return Json(true);
        }

        /// <summary>
        /// Этот метод проверяет свойство Description класса Product.
        /// Description должен быть больше 2 символов и не равен свойству Name класса Product.
        /// Description не может иметь последним символом string Empty.
        /// </summary>
        /// <param name="description"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public JsonResult ValidateDescriptionProduct(string description, string name)
        {
            if (description.Length <= 2)
                return Json("Description must be more than 2 characters");
            else if (name == null || description == name || !description.StartsWith(name) || description.EndsWith(" "))
                return Json("The description must not be the same as the name, but must start with the product name and end with a space char.");
            else
                return Json(true);
        }
    }
}
