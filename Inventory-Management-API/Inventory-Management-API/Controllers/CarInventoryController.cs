using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Inventory_Management_API.Models.DbEntities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventory_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarInventoryController : ControllerBase
    {
        CarInventoryContext _carInventoryContext = new CarInventoryContext();
        // GET: api/<CarInventoryController>
        [HttpGet]
        public IEnumerable<Inventory> Get()
        {
             var carlist = _carInventoryContext.Inventory.ToList();
            return carlist;
        }

        // GET api/<CarInventoryController>/5
        [HttpGet("{id}")]
        public Inventory Get(int id)
        {
            if(id == 0)
            {
                BadRequest();
            }

            var entity = _carInventoryContext.Inventory.FirstOrDefault(x => x.InventoryId == id);
            return entity;
        }

        // POST api/<CarInventoryController>
        [HttpPost]
        public IActionResult Post([FromBody] Inventory inventory)
        {
            if (inventory == null)
            {
                return BadRequest();
            }
            try
            {
                _carInventoryContext.Inventory.Add(inventory);
                _carInventoryContext.SaveChanges();

            }
            catch(Exception ex)
            {
                return BadRequest();
            }
            return Ok();
        }

        // PUT api/<CarInventoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Inventory inventory)
        {
            if (inventory == null)
            {
                return BadRequest();
            }
            try
            {
                var entity = _carInventoryContext.Inventory.FirstOrDefault(x => x.InventoryId == id);

                if(entity != null)
                {
                    entity.CarName = inventory.CarName;
                    entity.Model = inventory.Model;
                    entity.StockQty = inventory.StockQty;

                    _carInventoryContext.Update(entity);
                    _carInventoryContext.SaveChanges();

                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return Ok();
        }

        // DELETE api/<CarInventoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var entityToRemove = _carInventoryContext.Inventory.SingleOrDefault(x => x.InventoryId == id);
            if(entityToRemove != null)
            {
                _carInventoryContext.Inventory.Remove(entityToRemove);
                _carInventoryContext.SaveChanges();
            }
        }
    }
}
