using System;
using Microsoft.AspNetCore.Mvc;

namespace Web.Test.Controllers
{
    public class HomeController : Controller
    {
        public  IActionResult Index()
        {

            return View(new Product(){IsActive = true,CreateDate=DateTime.UtcNow.AddDays(0), Tags="1111,2222,3333"});
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
        public string Name { get; set; }
        public string Family { get; set; }
        public string Img { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Tags { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }


  
}