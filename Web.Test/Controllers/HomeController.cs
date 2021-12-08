using System;
using Microsoft.AspNetCore.Mvc;

namespace Web.Test.Controllers
{
    public class HomeController : Controller
    {
        public  IActionResult Index()
        {

            return View(new Product());
        }

        [HttpPost]
        public IActionResult Index(Product p)
        {
            var file = Request.Form.Files;

            return View(p);
        }

    }


    public class Product
    {
        public int Id { get; set; }
        public string Img { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}