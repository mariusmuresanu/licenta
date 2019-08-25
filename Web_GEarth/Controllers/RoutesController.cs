﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_GEarth.Models;
using Web_GEarth.Services;

namespace Web_GEarth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private IRouteService routeService;
        public RoutesController(IRouteService routeService)
        {
            this.routeService = routeService;
        }

        //GET: api/Routes
        [HttpGet]

        public IEnumerable<Route> Get([FromQuery]DateTime? from, [FromQuery]DateTime? to)
        {
            return routeService.GetAll(from, to);
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
        public void Post([FromBody] Route route)
        {
            routeService.Create(route);
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