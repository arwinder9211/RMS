using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RMS.Data;
using RMS.Models;
using RMS.Services;

namespace RMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private IRestaurantService restaurantService;
        private IDishService dishService;
        private ApplicationDbContext db;
        public AdminController(IRestaurantService _restaurantService, IDishService _dishService, ApplicationDbContext _db)
        {
            restaurantService = _restaurantService;
            dishService = _dishService;
            db = _db;
        }

        /// <summary>
        /// Show list of all restaurants
        /// </summary>
        /// <returns>View("Index")</returns>
        public IActionResult Index()
        {
            return View(restaurantService.Get());
        }

        /// <summary>
        /// Render view for add restaurant
        /// </summary>
        /// <returns>View("Add")</returns>
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        /// <summary>
        /// save restaurant in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns>View("Add")</returns>
        [HttpPost]
        public IActionResult Add(RestaurantViewModel model)
        {
            try
            {
                restaurantService.Add(model);
                ViewBag.Msg = "Restaurant Added Successfully";
            }
            catch
            {
                ViewBag.Error = "Something went wrong. Try Again later";
            }

            return View();
        }

        /// <summary>
        /// Details of a restaurant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult DetailsRest(int id)
        {
           
            return View(restaurantService.Get(id));
        }

        /// <summary>
        /// Render view for edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditRest(int id)
        {
            return View(restaurantService.Get(id));
        }


        /// <summary>
        /// edit restaurant
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EditRest(int id, RestaurantViewModel model)
        {
            try
            {
                restaurantService.Edit(id, model);
                ViewBag.Msg = "Restaurant Edited Successfully";
            }
            catch
            {
                ViewBag.Error = "Something went wrong. Try Again later";
            }

            return View();
        }

        /// <summary>
        /// delete restaurant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            restaurantService.Delete(id);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// show list of dishes
        /// </summary>
        /// <returns></returns>
        public IActionResult Dishes()
        {
            return View(dishService.Get());
        }

        /// <summary>
        /// Dish of seleted restaurant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult DishesOfRestaurant(int id)
        {

            return View("Dishes", dishService.GetDishesOfRestaurant(id));
        }

        /// <summary>
        /// Render view for create dish
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateDish()
        {
            ViewBag.Restaurants = restaurantService.Get();
            return View();
        }

        /// <summary>
        /// save dish to database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateDish(Dish model)
        {
            try
            {
                dishService.Add(model);
                ViewBag.Msg = "Dish Created Successfully";
            }
            catch
            {
                ViewBag.Error = "Error";
            }
            ViewBag.Restaurants = restaurantService.Get();
            return View();
        }

        /// <summary>
        /// delete dish
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult DeleteDish(int id)
        {
            dishService.Delete(id);
            return RedirectToAction("Dishes");
        }

        /// <summary>
        /// render view for edit dish
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult EditDish(int id)
        {
            ViewBag.Restaurants = restaurantService.Get();
            return View(dishService.Get(id));
        }

        /// <summary>
        /// Update dish in database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EditDish(int id, Dish model)
        {
            try
            {
                if (dishService.Edit(id, model))
                {
                    ViewBag.Msg = "Success";
                }
                else
                {
                    ViewBag.Error = "Error";
                }

            }
            catch
            {
                ViewBag.Error = "Error";
            }
            ViewBag.Restaurants = restaurantService.Get();
            return View(dishService.Get(id));
        }

        /// <summary>
        /// View List of users
        /// </summary>
        /// <returns>View("Users")</returns>
        [HttpGet]
        public IActionResult Users()
        {
            return View(db.Customers.ToList());
        }


    }
}