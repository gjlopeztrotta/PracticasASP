using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Filters;
using WebApplication1.Models;
using WebApplication1.Models.Repositories;
using WebApplication1.Models.Validations;


namespace WebApplication1.Controllers
{
    [ApiController]
    public class ShirtsController: ControllerBase
    {

        [HttpGet]
        [Route("/shirts")]
        public IActionResult GetShirts()
        {
           var shirt= ShirtRepository.GetShirts();
            if (shirt==null)
                return NotFound();

            return Ok(shirt);

        }

        [HttpGet]
        [Route("/shirts/{id}")]
        [Shirt_ValidateShirtIdFilterAtribute]
          public IActionResult GetShirtsById(int id)
        {
            return Ok(ShirtRepository.GetShirtById(id));
        }

        [HttpPost]
        [Route("/shirts")]
        [Shirt_ValidateCreateShirtFilterAttribute]
        public IActionResult CreateShirts([FromBody] Shirt shirt)
        {
           
            ShirtRepository.AddShirt(shirt);

            return CreatedAtAction(nameof(GetShirtsById), new {id=shirt.ShirtId},shirt);
        }

        [HttpPut]
        [Route("/shirts/{id}")]
        [Shirt_ValidateShirtIdFilterAtribute]
        public IActionResult UpdateShirts(int id, Shirt shirt)
        {
            if(id != shirt.ShirtId) return BadRequest();
            try
            {
            ShirtRepository.UpdateShirt(shirt); return NoContent();
            }
            catch{
                if (!ShirtRepository.ShirtExists(id)) 
                return NotFound("shirt not found");
                throw;
            }

            
            
        }

        [HttpDelete]
        [Route("/shirts/{id}")]
          public String DeleteShirts(int id)
        {
            return "Deleting a shirt:{id}";
        }


    }
}