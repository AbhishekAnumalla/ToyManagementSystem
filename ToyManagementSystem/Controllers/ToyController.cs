using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToyManagementSystem.Models;
using ToyManagementSystem.Repository;

namespace ToyManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToyController : ControllerBase
    {
        IToyClass service;

        public ToyController(IToyClass _service)
        {
            service = _service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var list = service.getToys();
                return Ok(list);
            }

            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        /*[HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            try
            {
                var list = service.getToy(id);
                return Ok(list);
            }

            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }*/

        //Uncomment for Consuming using Mvc Http Client

        [HttpGet("{id}")]
        [Route("GetToy/{id}")]

        public IActionResult GetToy(int id)
        {
            try
            {
                Toy toy= service.getToy(id);
                return Ok(toy);
            }

            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Toy Toy)
        {
            try
            {
                var res = service.addToy(Toy);
                return Ok(res);
            }

            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut/*("{id}")*/]
        [Route("Put")]

        public IActionResult Put(Toy toy)
        {
            try
            {
                service.updateToy(toy);
                return Ok("Updated Records!");
            }
            catch(Exception)
            {
                return NotFound("Unable to update records.");
            }
        }

        [HttpDelete("{id}")]
        
        public IActionResult delete(int id)
        {
            try
            {
                service.deleteToy(id);
                return Ok("Deleted Record!");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
