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
    public class CategoryController : ControllerBase
    {
        ICategoryClass service;

        public CategoryController(ICategoryClass _service)
        {
            service = _service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var list = service.GetCategories();
                return Ok(list);
            }

            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var list = service.GetCategory(id);
                return Ok(list);
            }

            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Category category)
        {
            try
            {
                var res = service.addCategory(category);
                return Ok(res);
            }

            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
