using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dapperTest.Models;
using dapperTest.Factory;

namespace dapperTest.Controllers
{
    public class HomeController : Controller
    {

        private readonly UserFactory _userFactory;
        public HomeController(UserFactory uFactory)
        {
            _userFactory = uFactory;
        }


        [HttpGet("")]
        public IActionResult Index()
        {

            ViewBag.Users = _userFactory.FindAll();

            return View();
        }


        public IActionResult addHikeView()
        {

            return View("NewTrail");
        }

        [HttpPost("Home/addTrail")]
        public IActionResult addTrail(User user)
        {
            if (ModelState.IsValid)
            {
                _userFactory.Add(user);
                Console.WriteLine("From is valid");

                return RedirectToAction("Index");
            }
            else
            {
                Console.WriteLine("form is not valid");
                return RedirectToAction("addHikeView");
            }
        }


        [HttpGet("Home/TrailView")]
        public IActionResult TrailView(int id){
            
            ViewBag.user=_userFactory.FindByID(id);
            return View();
        }




        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
