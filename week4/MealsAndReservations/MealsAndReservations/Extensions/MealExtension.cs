using System;
using MealsAndReservations.Dtos;
using MealsAndReservations.Models;

namespace MealsAndReservations.Extensions
{
	public static class MealExtension
	{
		public static MealDto AsDto(this Meal meal)
        {
			return 
				new MealDto {
					Id = meal.Id,
					Cost = meal.Cost,
					Location = meal.Location,
					MaxReservations = meal.MaxReservations,
					Title = meal.Title
				};
        }
	}
}

