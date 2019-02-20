using Microsoft.EntityFrameworkCore;
using RMS.Data;
using RMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMS.DAL
{
    public interface IDishRepo
    {
        List<Dish> Get();
        Dish Get(int id);
        void Add(Dish model);
        bool Delete(int id);
        bool Edit(int id, Dish model);
        List<Dish> GetDishesOfRestaurant(int id);

    }
    public class DishRepo: IDishRepo
    {
        private ApplicationDbContext db;

        public DishRepo(ApplicationDbContext _db)
        {
            db = _db;
        }

        /// <summary>
        /// get list of all dishes
        /// </summary>
        /// <returns>List<Dish> dishes</returns>
        public List<Dish> Get()
        {
            return db.Dishes.Include(r => r.Restaurant).ToList();
        }

        /// <summary>
        /// get dish by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Dish dish</returns>
        public Dish Get(int id)
        {
            return db.Dishes.Include(r => r.Restaurant).FirstOrDefault(r => r.Id == id);
        }

        /// <summary>
        /// add dish to database
        /// </summary>
        /// <param name="model"></param>
        public void Add(Dish model)
        {
            db.Dishes.Add(model);
            db.SaveChanges();

        }

        /// <summary>
        /// delete dish
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            try
            {
                var dish = db.Dishes.FirstOrDefault(r => r.Id == id);
                if (dish == null)
                {
                    return false;
                }

                db.Dishes.Remove(dish);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Update dish
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns>boolean </returns>
        public bool Edit(int id, Dish model)
        {
            try
            {
                var dish = db.Dishes.FirstOrDefault(r => r.Id == id);
                if (dish == null)
                {
                    return false;
                }

                dish.Description = model.Description;
                dish.Name = model.Name;
                dish.Price = model.Price;
                dish.Id = model.Id;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// get all dishes of restaurant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Dish> GetDishesOfRestaurant(int id)
        {
            return db.Dishes.Include(r => r.Restaurant).Where(d => d.RestaurantId == id).ToList();
        }
    }
}
