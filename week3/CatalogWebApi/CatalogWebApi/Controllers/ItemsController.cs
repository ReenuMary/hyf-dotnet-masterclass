using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogWebApi.Entities;
using CatalogWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using CatalogWebApi.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CatalogWebApi.Controllers;

[Route("api/[controller]")]
public class ItemsController : Controller
{

    private readonly IRepositoryItems itemRepository;
    public ItemsController(IRepositoryItems repositoryItems)
    {
        itemRepository = repositoryItems;
    }

    // GET: api/values
    [HttpGet]
    public async Task< IEnumerable<ItemDto> >GetItemsAync()
    {
        var items = (await itemRepository.GetItemsAsync())
                    .Select(x=>x.AsDto());
        return items;
    }


    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
    {
        var item = await itemRepository.GetItemAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item.AsDto());
    }

    // POST api/values
    [HttpPost]
    public async Task<ActionResult<ItemDto>> PostAsync(CreateItemDto createItemDto)
    {
        Item item = new();
        item = new Item
        {
            CreationDate = DateTimeOffset.UtcNow,
            Id = Guid.NewGuid(),
            Name = createItemDto.Name,
            Price = createItemDto.Price
        };
        await itemRepository.AddItemAsync(item);

        return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDto());
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemDto updateItemDto)
    {
        Item? existingItem = await itemRepository.GetItemAsync(id);
        if(existingItem is null)
        {
            return NotFound();
        }

        Item updatedItem = existingItem with
        {
            Name = updateItemDto.Name,
            Price = updateItemDto.Price
        };

        await itemRepository.UpdateItemAsync(updatedItem);

        return NoContent();
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        var existingItem = await itemRepository.GetItemAsync(id);
        if(existingItem is null)
        {
            return NotFound();
        }
       await itemRepository.DeleteItemAsync(id);
        return NoContent();
    }
}



