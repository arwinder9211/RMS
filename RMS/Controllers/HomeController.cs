using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RMS.Models;
using RMS.Services;

namespace RMS.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IRestaurantService restaurantService;
        private IDishService dishService;
        public HomeController(IRestaurantService _restaurantService, IDishService _dishService)
        {
            restaurantService = _restaurantService;
            dishService = _dishService;
        }

        /// <summary>
        /// View All Restaurants
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(restaurantService.Get());
        }


        /// <summary>
        /// View Selected Restaurant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult RestaurantDetails(int id)
        {
            return View(restaurantService.Get(id));
        }
        /// <summary>
        /// View All Dishes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Dishes()
        {
            return View(dishService.Get());
        }

        /// <summary>
        /// View Dishes of selected restaurant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult DishesOfRestaurant(int id)
        {

            return View("Dishes", dishService.GetDishesOfRestaurant(id));
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
    }
}
