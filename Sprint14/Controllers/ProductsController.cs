using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsWithRouting.Models;
using ProductsWithRouting.Services;

namespace ProductsWithRouting.Controllers
{
    public class ProductsController : Controller
    {
        private List<Product> myProducts;

        public ProductsController(Data data)
        {
            myProducts = data.Products;
        }

        /// <summary>
        /// Данный метод выводит список продуктов.
        /// </summary>
        /// <param name="filterId"></param>
        /// <param name="filtername"></param>
        /// <returns></returns>       

        [Route("items/index")]
        [Route("items")]
        [Route("[controller]")] 
        [Route("[controller]/[action]/{filterId}/{filtername}")]
        [Route("[controller]/[action]/{filterId:int?}")]
        [Route("[controller]/[action]/{filtername}")]

        public IActionResult Index(int filterId, string filtername) => (filterId, filtername) switch
        {
            (0, null) => View(myProducts),
            (_, null) => myProducts.All(product => product.Id != filterId) ?
                                                          View("Error") : View(myProducts.Where(product => product.Id == filterId)),
            (0, _) => myProducts.All(product => product.Name != filtername) ?
                                                                 View("Error") : View(myProducts.Where(product => product.Name == filtername)),
            (_, _) => myProducts.Find(product => product.Id == filterId).Equals(myProducts.Find(product => product.Name == filtername)) == true ?
                                                                       View(myProducts.Where(product => product.Id == filterId)) : View("Error"),
        };        

        /// <summary>
        /// Данный метод выводит представление о продукте (окно информации)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        [Route("Products/{id:int}")]

        public IActionResult View(int id)
        {
            var product = myProducts.Find(product => product.Id == id);
            return product != null ? View(product) : View("Error");
        }

        /// <summary>
        /// Данный метод вызывает представление дял редакции объекта класса Продукт
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>        
        [HttpGet("[controller]/[action]/{id:int}")]

        public IActionResult Edit(int id)
        {
            var product = myProducts.Find(product => product.Id == id);
            return product != null ? View(product) : View("Error");
        }

        /// <summary>
        /// Данный метод изменяет свойства объект класса Продукт
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>        
        [HttpPost]

        public IActionResult Edit(Product product)
        {
            myProducts[myProducts.FindIndex(x => x.Id == product.Id)] = product;
            return View("~/Views/Products/Index.cshtml", myProducts);
        }

        /// <summary>
        /// Данный метод добавляет объект класса Продукт в массив
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>    
        [HttpPost("[controller]/[action]")]

        public IActionResult Create(Product product)
        {
            myProducts.Add(product);
            return View("~/Views/Products/Index.cshtml", myProducts);
        }

        /// <summary>
        /// Данный метод вызывает представление для создания объект класса Продукт
        /// </summary>
        /// <returns></returns> 
        [Route("products/new")]
        [Route("[controller]/[action]")]

        public IActionResult Create()
        {
            return View(new Product() { Id = myProducts.Max(product => product.Id) + 1 });
        }

        /// <summary>
        /// Данный метод удаляет объет продукт из массива
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [Route("[controller]/[action]/{id:int}")]

        public IActionResult Delete(int id)
        {
            if (myProducts.All(product => product.Id != id))
                return View("Error");
            else
                myProducts.Remove(myProducts.Find(product => product.Id == id));
            return View("Index", myProducts);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
