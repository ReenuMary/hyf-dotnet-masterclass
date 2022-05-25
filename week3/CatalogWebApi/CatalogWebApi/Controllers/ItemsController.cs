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

    private readonly IInMemRepositoryItems itemRepository;
    public ItemsController(IInMemRepositoryItems repositoryItems)
    {
        itemRepository = repositoryItems;
    }

    // GET: api/values
    [HttpGet]
    public IEnumerable<ItemDto> GetItems()
    {
        var items = itemRepository.GetItems().Select(x=>x.AsDto());
        return items;
    }


    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<ItemDto> GetItem(Guid id)
    {
        var item = itemRepository.GetItem(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item.AsDto());
    }

    // POST api/values
    [HttpPost]
    public ActionResult<ItemDto> Post(CreateItemDto createItemDto)
    {
        Item item = new();
        item = new Item
        {
            CreationDate = DateTimeOffset.UtcNow,
            Id = Guid.NewGuid(),
            Name = createItemDto.Name,
            Price = createItemDto.Price
        };
        itemRepository.AddItem(item);

        return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult UpdateItem(Guid id, UpdateItemDto updateItemDto)
    {
        Item? existingItem = itemRepository.GetItem(id);
        if(existingItem is null)
        {
            return NotFound();
        }

        Item updatedItem = existingItem with
        {
            Name = updateItemDto.Name,
            Price = updateItemDto.Price
        };

        itemRepository.UpdateItem(updatedItem);

        return NoContent();
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        var existingItem = itemRepository.GetItem(id);
        if(existingItem is null)
        {
            return NotFound();
        }
        itemRepository.DeleteItem(id);
        return NoContent();
    }
}
/*
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
*/



