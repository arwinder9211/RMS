using Microsoft.EntityFrameworkCore;
using RMS.Data;
using RMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMS.DAL
{
    public interface IRestaurantRepo
    {
        List<Restaurant> Get();
        Restaurant Get(int id);
        void Add(Restaurant model);
        bool Delete(int id);
        bool Edit(int id, Restaurant model);
        Address Address(int id);
    }
    public class RestaurantRepo : IRestaurantRepo
    {
        private ApplicationDbContext db;

        public RestaurantRepo(ApplicationDbContext _db)
        {
            db = _db;
        }

        /// <summary>
        /// Get list of all restaurant
        /// </summary>
        /// <returns>List<Restaurant></returns>
        public List<Restaurant> Get()
        {
            return db.Restaurants.Include(d => d.Dishes).Include(a => a.Addresses).ToList();
        }

        /// <summary>
        /// Get restaurant by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Restaurant restaurant</returns>
        public Restaurant Get(int id)
        {
            return db.Restaurants.Include(d => d.Dishes).Include(a => a.Addresses).FirstOrDefault(r => r.Id == id);
        }

        /// <summary>
        /// Add data to the database
        /// </summary>
        /// <param name="model"></param>
        public void Add(Restaurant model)
        {
            db.Restaurants.Add(model);
            db.SaveChanges();

        }

        /// <summary>
        /// delete data from database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            try
            {
                var restaurant = db.Restaurants.FirstOrDefault(r => r.Id == id);
                if (restaurant == null)
                {
                    return false;
                }

                db.Restaurants.Remove(restaurant);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// edit restaurant and update it
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Edit(int id, Restaurant model)
        {
            try
            {
                var restaurant = db.Restaurants.FirstOrDefault(r => r.Id == id);
                if (restaurant == null)
                {
                    return false;
                }

                restaurant.Description = model.Description;
                restaurant.Name = model.Name;
                restaurant.Type = model.Type;
                var addressId = model.Addresses.First().Id;
                var address = db.Addresses.FirstOrDefault(a => a.Id == addressId);
                address.City = model.Addresses.First().City;
                address.Street = model.Addresses.First().Street;
                address.Country = model.Addresses.First().Country;
                address.PostalCode = model.Addresses.First().PostalCode;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Get address of a restauarnt
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Address Address(int id)
        {
            return db.Addresses.FirstOrDefault(a => a.RestaurantId == id);
        }
    }
}
