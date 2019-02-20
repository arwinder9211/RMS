using RMS.DAL;
using RMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMS.Services
{
    public interface IRestaurantService
    {
        List<Restaurant> Get();
        RestaurantViewModel Get(int id);
        void Add(RestaurantViewModel model);
        bool Delete(int id);
        bool Edit(int id, RestaurantViewModel model);
        //Address Address(int id);
    }
    public class RestaurantService : IRestaurantService
    {
        private IRestaurantRepo restaurantRepo;
        public RestaurantService(IRestaurantRepo _restaurantRepo)
        {
            restaurantRepo = _restaurantRepo;
        }

        /// <summary>
        /// save data to database
        /// </summary>
        /// <param name="model"></param>
        public void Add(RestaurantViewModel model)
        {
            var list = new List<Address>();
            list.Add(new Address()
            {
                Street = model.Street,
                City = model.City,
                Country = model.Country,
                PostalCode = model.PostalCode
            });
            var restaurant = new Restaurant()
            {
                Description = model.Description,
                Name = model.Name,
                Type = model.Type,
                Addresses = list
            };
            restaurantRepo.Add(restaurant);
        }

        //public Address Address(int id)
        //{
        //    //throw new NotImplementedException();
        //}

        public bool Delete(int id)
        {
            return restaurantRepo.Delete(id);
        }


        /// <summary>
        /// Edit restaurant and address
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Edit(int id, RestaurantViewModel model)
        {
            var list = new List<Address>();
            list.Add(new Address()
            {
                Street = model.Street,
                City = model.City,
                Country = model.Country,
                PostalCode = model.PostalCode,
                Id = model.AddressId
            });
            var restaurant = new Restaurant()
            {

                Description = model.Description,
                Name = model.Name,
                Type = model.Type,
                Addresses = list
            };
            return restaurantRepo.Edit(id,restaurant);
        }

        /// <summary>
        /// List of all restaurants
        /// </summary>
        /// <returns></returns>
        public List<Restaurant> Get()
        {
            return restaurantRepo.Get();
        }

        /// <summary>
        /// Get restaurant by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ResttaurantViewModel restaurant</returns>
        public RestaurantViewModel Get(int id)
        {
            var restaurant = restaurantRepo.Get(id);
            var restaurantViewModel = new RestaurantViewModel()
            {
                City = restaurant.Addresses.First().City,
                Country = restaurant.Addresses.First().Country,
                Description = restaurant.Description,
                Name = restaurant.Name,
                PostalCode = restaurant.Addresses.First().PostalCode,
                Street = restaurant.Addresses.First().Street,
                Type = restaurant.Type,
                AddressId = restaurant.Addresses.First().Id

            };
            return restaurantViewModel;
        }
    }
}
