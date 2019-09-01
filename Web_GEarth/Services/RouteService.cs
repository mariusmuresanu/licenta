using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_GEarth.Models;
using Web_GEarth.ViewModels;
using Route = Web_GEarth.Models.Route;

namespace Web_GEarth.Services
{
    public interface IRouteService
    {
        IEnumerable<RouteGetModel> GetAll(DateTime? from=null, DateTime? to=null);
        Route GetById(int id);
        Route Create(RoutePostModel route);
        Route Upsert(int id, Route route);
        Route Delete(int id);
    }
    public class RouteService : IRouteService
    {
        private RoutesDbContext context;
        public RouteService(RoutesDbContext context)
        {
            this.context = context;
        }

        public Route Create(RoutePostModel route)
        {
            Route toAdd = RoutePostModel.ToRoute(route);
            context.Routes.Add(toAdd);
            context.SaveChanges();
            return toAdd;
        }

        public Route Delete(int id)
        {
            var existing = context.Routes
                .Include(r =>r.Comments)
                .FirstOrDefault(route => route.Id == id);
            if (existing == null)
            {
                return null;
            }
            context.Routes.Remove(existing);
            context.SaveChanges();
            return existing;
        }

        public IEnumerable<RouteGetModel> GetAll(DateTime? from=null, DateTime? to=null)
        {
            IQueryable<Route> result = context
                .Routes
                .Include(r => r.Comments);
            if (from == null && to == null)
            {
                return result.Select(r => RouteGetModel.FromRoute(r));
            }
            if (from != null)
            {
                result = context.Routes.Where(r => r.DateRecorded >= from);
            }
            if (to != null)
            {
                result = context.Routes.Where(r => r.DateRecorded <= to);
            }
            return result.Select(r => RouteGetModel.FromRoute(r));
        }

        public Route GetById(int id)
        {
            return context.Routes
                 .Include(r => r.Comments)
                 .FirstOrDefault(r => r.Id == id);
        }

        public Route Upsert(int id, Route route)
        {
            var existing = context.Routes.AsNoTracking().FirstOrDefault(r => r.Id == id);
            if (existing == null)
            {
                context.Routes.Add(route);
                context.SaveChanges();
                return route;
            }
            route.Id = id;
            context.Routes.Update(route);
            context.SaveChanges();
            return route;
        }
    }
}
