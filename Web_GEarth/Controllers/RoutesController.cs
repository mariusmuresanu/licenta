using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_GEarth.Models;
using Web_GEarth.Services;
using Web_GEarth.ViewModels;

namespace Web_GEarth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private IRouteService routeService;
        private IUsersService usersService;
        public RoutesController(IRouteService routeService, IUsersService usersService)
        {
            this.routeService = routeService;
            this.usersService = usersService;
        }

        //GET: api/Routes
        [HttpGet]

        public PaginatedList<RouteGetModel> Get([FromQuery]DateTime? from, [FromQuery]DateTime? to, [FromQuery]int page = 1)
        {
            page = Math.Max(page, 1);
            return routeService.GetAll(page, from, to);
        }

        //GET api/Routes/5

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var found = routeService.GetById(id);
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }

        //POST: api/Routes

        [HttpPost]
        public void Post([FromBody] RoutePostModel route)
        {
            User addedBy = usersService.GetCurrentUser(HttpContext);
            routeService.Create(route, addedBy);
        }

        //PUT: api/Routes/5

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Route route)
        {
            var result = routeService.Upsert(id, route);
            return Ok(result);
        }

        //DELETE: api/ApiWithActions/5

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            var result = routeService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}