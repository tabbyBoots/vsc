using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace mvcdemo.Controllers
{
    public class RazorDemoController : Controller
    {
        public IActionResult Demo01()
        {
            return View();
        }

        public IActionResult Demo02()
        {
            return View();
        }
        public IActionResult Demo03()
        {
            return View();
        }
        public IActionResult Demo04()
        {
            return View();
        }
        public IActionResult Demo05()
        {
            return View();
        }
        public IActionResult Demo06()
        {
            return View();
        }
        public IActionResult Demo07()
        {
            return View();
        }
        public IActionResult Demo08()
        {
            return View();
        }
        public IActionResult Demo09()
        {
            return View();
        }
        public IActionResult Demo10()
        {
            return View();
        }
        public IActionResult Demo11()
        {
            return View();
        }
        public IActionResult Demo12()
        {
            return View();
        }
        public IActionResult Demo13()
        {
            return View();
        }
        public IActionResult Demo14()
        {
            return View();
        }
        public IActionResult Demo15()
        {
            return View();
        }
        public IActionResult Demo16()
        {
            List<Person> model = new List<Person>(){
                new Person(){Id = 1 , PersonNo = "P001" , PersonName ="王大明"},
                new Person(){Id = 2 , PersonNo = "P002" , PersonName ="李小華"},
                new Person(){Id = 3 , PersonNo = "P003" , PersonName ="陳小光"},
                new Person(){Id = 4 , PersonNo = "P004" , PersonName ="吳小月"},
                new Person(){Id = 5 , PersonNo = "P005" , PersonName ="楊小風"}
            };
            return View(model);
        }
        public IActionResult Demo17()
        {
            ViewData["UserNo"] = "U001";
            TempData["UserNo"] = "U002";
            return View();
        }
        public IActionResult Demo18()
        {
            var items = new List<SelectListItem>()
    {
        new SelectListItem() { Text = "VIP客戶", Value = "VIP" },
        new SelectListItem() { Text = "一般客戶", Value = "NORMAL" },
        new SelectListItem() { Text = "拒往客戶", Value = "REJECT" }
    };
            ViewData["Item1"] = items;
            ViewBag.Item2 = items;
            TempData["Item3"] = items;
            return View();
        }










    }
}