using System;
using System.ComponentModel.DataAnnotations;

namespace MealsAndReservations.Dtos
{
	public record UpdateMealDto
	{
        [Required]
        public string? Location { get; set; }
        [Required]
        public int Cost { get; set; }
        [Required]
        public int MaxReservations { get; set; }
	}
}

