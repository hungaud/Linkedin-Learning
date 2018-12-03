using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using H_Plus_Sports.Models;

namespace H_Plus_Sports.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly H_Plus_SportsContext _context;

        public CustomersController(H_Plus_SportsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCustomer()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult getCustomer([FromRoute] int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult PostCustomer([FromBody] Object obj)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult PutCustomer([FromRoute] int id, [FromBody] Object obj)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer([FromRoute] int id)
        {
            return Ok();
        }
    }
}