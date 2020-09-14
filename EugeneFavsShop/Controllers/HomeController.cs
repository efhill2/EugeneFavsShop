using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EugeneFavsShop.Models;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace EugeneFavsShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
        public IActionResult RegistrationSummary(string firstname,
            string lastname,
            string email,
            string phonenumber,
            string password,
            string pwconfirm,
            string state,
            string city,
            string choice)
        {
            Users user = new Users()
            {
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                PhoneNumber = phonenumber,
                Password = password,
                State = state,
                City = city,
                Choice = choice
            };

            ViewBag.Welcome = $"Welcome, {firstname} {lastname}!";

            if (password != pwconfirm)
            {
                ViewBag.PasswordStatusMessage = "Passwords do not match!! <br / >";
                return View("Registration");
            }
            else if ((!Regex.IsMatch(phonenumber, @"(\([0-9]{3}\)\-[0-9]{3}\-[0-9]{4})")) & ((!Regex.IsMatch(phonenumber, @"([0-9]{3}\.[0-9]{3}\.[0-9]{4})"))))
            {
                ViewBag.PhoneNumberStatusMessage = "Phone number needs to be in (XXX)-XXX-XXXX or (XXX).XXX.XXXX <br / >";
                return View("Registration");
            }
            else
            {
                return View(user);
            }
            
        }  
        public IActionResult Order()
        {
            return View();
        }
        public IActionResult OrderSummary(string drinkselection,
            string drinksize,
            string userchoice,
            string pickup,
            string delivery,
            string pickuptime)
        {
            Orders order = new Orders()
            {
                DrinkSelection = drinkselection,
                DrinkSize = drinksize,
                UserChoice = userchoice,
                PickUpTime = pickuptime,
                Delivery = delivery
            };

            

            if (userchoice == pickup)
            {
                ViewBag.PickUpMessage = "Your order will be ready for pick up at @Model.PickUpTime.";

            }
            else if (userchoice == delivery)
            {
                ViewBag.DeliveryMessage = "Your order will be delivered to you in about 20 minutes.";
            }

            return View(order);
        }

        public IActionResult Privacy()
        {            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
