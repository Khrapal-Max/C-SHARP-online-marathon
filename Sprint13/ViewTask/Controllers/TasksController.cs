using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ViewTask.Models;

namespace ViewTask.Controllers
{
    public class TasksController : Controller
    {
        private List<Product> Products => new List<Product>
        {
            new Product() { Name = "Bread", Price = 10 },
            new Product() { Name = "Milk", Price = 11 },
            new Product() { Name = "Cheese", Price = 140 },
            new Product() { Name = "Sausage", Price = 110 },
            new Product() { Name = "Potato", Price = 7 },
            new Product() { Name = "Banana", Price = 23 },
            new Product() { Name = "Tomato", Price = 25 },
            new Product() { Name = "Candy", Price = 75 }
        };
        List<string> markets => new List<string>
        {
            "WellMart",
            "Silpo",
            "ATB",
            "Furshet",
            "Metro"
        };
        private Dictionary<string, int> ListProducts => new Dictionary<string, int>
        {
            { "Milk", 2 },
            {"Bread", 2 },
            {"Cake", 1 },
            {"Ice Cream", 5 },
            {"Cola", 10 },
        };
        /// <summary>
        /// Этот метод вызывает метод SprintTasks
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View("SprintTasks");
        }
        /// <summary>
        /// Этот метод вызывает представдление для навигации TasksController
        /// </summary>
        /// <returns></returns>
        public IActionResult SprintTasks()
        {
            return View();
        }
        /// <summary>
        /// Этот метод вывод представление с приветствием для пользователя
        /// </summary>
        /// <returns></returns>
        public IActionResult Greetings()
        {
            return View();
        }
        /// <summary>
        /// Этот метод вывод список продуктов
        /// </summary>
        /// <returns></returns>
        public IActionResult ProductInfo()
        {
            return View(Products);
        }
        /// <summary>
        /// Этот метод выводит список магазинов
        /// </summary>
        /// <returns></returns>
        public IActionResult SuperMarkets()
        {          
            ViewBag.Markets = markets;
            return View();
        }
        /// <summary>
        /// Этот метод вызывает представление с списком товара (название и количество)
        /// </summary>
        /// <returns></returns>
        public IActionResult ShoppingList()
        {
            return PartialView(ListProducts);
        }
        /// <summary>
        /// Этот метод работает с корзиной покупателя
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ShoppingCart()
        {
            return View(ListProducts);
        }
        [HttpPost]
        public IActionResult ShoppingCart(string name, string address)
        {
            string authData = $"You products will be shipped at: {address}. Bon appetite, {name}";
            return Content(authData);
        }
    }
}
