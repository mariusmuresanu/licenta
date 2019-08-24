using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_GEarth.Models;

namespace Web_GEarth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private RoutesDbContext context;
        public RoutesController(RoutesDbContext context)
        {
            this.context = context;
        }

        //GET: api/Routes
        [HttpGet]

        public IEnumerable<Route> Get()
        {
            return context.Routes.Include(r => r.Comments);
        }

        //GET api/Routes/5

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var existing = context.Routes.FirstOrDefault(route => route.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            return Ok(existing);
        }

        //POST: api/Routes

        [HttpPost]
        public void Post([FromBody] Route route)
        {
            //if(!ModelState.IsValid)
            //{
            //}
            context.Routes.Add(route);
            context.SaveChanges();
        }

        //PUT: api/Routes/5

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Route route)
        {
            var existing = context.Routes.AsNoTracking().FirstOrDefault(r => r.Id == id);
            if (existing == null)
            {
                context.Routes.Add(route);
                context.SaveChanges();
                return Ok(route);
            }
            route.Id = id;
            context.Routes.Update(route);
            context.SaveChanges();
            return Ok(route);
        }

        //DELETE: api/ApiWithActions/5

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        { 
            var existing = context.Routes.AsNoTracking().FirstOrDefault(r => r.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            context.Routes.Remove(existing);
            context.SaveChanges();
            return Ok();
        }
    }
}