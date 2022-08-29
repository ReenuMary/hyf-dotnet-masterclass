using System;
namespace MealsAndReservations.Models
{
	public record Reservation
	{
        public Guid Id { get; init; }
        public Guid MealId{ get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateOnly Date { get; set; }
        public int PersonCount { get; set; }
    }
}

