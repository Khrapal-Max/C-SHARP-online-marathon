using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ProductsValidation.Models;
using ProductsValidation.Services;

namespace ProductsValidation.Controllers
{
    public class UsersController : Controller
    {
        private List<User> users;

        public UsersController(Data data)
        {
            users = data.Users;
        }

        public IActionResult Index(string id) => View(users);

        public IActionResult Create()
        {
            var user = new User()
            {
                Name = Request.Query["Name"],
                Email = Request.Query["Email"],
                Role = Request.Query["Role"]
            };
            return View(user);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            users.Add(user);
            return View("ViewNewUser", user);
        }

        public IActionResult ViewNewUser(User user) => View(user);

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
