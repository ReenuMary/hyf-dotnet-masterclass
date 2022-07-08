using System;
using CatalogWebApi.Entities;

namespace CatalogWebApi.Dtos
{
	public static class DtoExtensions
	{
		public static ItemDto AsDto(this Item item)
        {
			return new ItemDto
			{
				Id = item.Id,
				Name = item.Name,
				Price = item.Price,
				CreationDate = item.CreationDate

			};
        }
	}
}

