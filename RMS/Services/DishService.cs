using RMS.DAL;
using RMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMS.Services
{
    public interface IDishService
    {
        List<Dish> Get();
        Dish Get(int id);
        void Add(Dish model);
        bool Delete(int id);
        bool Edit(int id, Dish model);
        List<Dish> GetDishesOfRestaurant(int id);
    }
    public class DishService: IDishService  
    {
        private IDishRepo dishRepo;
        public DishService(IDishRepo _dishRepo)
        {
            dishRepo = _dishRepo;
        }

        public void Add(Dish model)
        {
            dishRepo.Add(model);
        }

        public bool Delete(int id)
        {
            return dishRepo.Delete(id);
        }

        public bool Edit(int id, Dish model)
        {
            return dishRepo.Edit(id,model);
        }

        public List<Dish> Get()
        {
            return dishRepo.Get();
        }

        public Dish Get(int id)
        {
            return dishRepo.Get(id);
        }

        public List<Dish> GetDishesOfRestaurant(int id)
        {
            return dishRepo.GetDishesOfRestaurant(id);
        }
    }

}
