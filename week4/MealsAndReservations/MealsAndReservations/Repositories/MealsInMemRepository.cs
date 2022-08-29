using System;
using MealsAndReservations.Models;

namespace MealsAndReservations.Repositories
{
    public class MealsInMemRepository : IMealsRepository
    {
        private readonly List<Meal> meals = new()
        {
         new Meal { Id = Guid.NewGuid(), Location = "Abcd alle 100,1000,Cph", MaxReservations = 5, Title = "Rice and Curry" },
         new Meal { Id = Guid.NewGuid(), Location = "Efg street 100,2000,Cph", MaxReservations = 10, Title = "Naan and Curry" },
         new Meal { Id = Guid.NewGuid(), Location = "Hij street 300,2001,Cph", MaxReservations = 8, Title = "Fish and chips" },
        };
        public async Task<List<Meal>> GetMealsAsync()
        {
            return await Task.FromResult(meals);
        }

        public async Task<Meal?> GetMealByIdAsync(Guid id)
        {
            var meal = meals.Find(x => x.Id == id);
            return await Task.FromResult(meal);
        }

        public async Task CreateMealAsync(Meal meal)
        {
            meals.Add(meal);
            await Task.CompletedTask;
        }

        public async Task UpdateMealAsync(Meal meal)
        {
            int index = meals.FindIndex(x => x.Id == meal.Id);
            meals[index] = meal;
            await Task.CompletedTask;

        }

        public async Task DeleteMealAsync(Guid id)
        {
            int index = meals.FindIndex(x => x.Id == id);
            meals.RemoveAt(index);

            await Task.CompletedTask;
        }
    }
}

