using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_GEarth.Services
{
    public interface IRouteService
    {
        IEnumerable<Route> GetAll();
        void Create(Route route);
        void Update(int id, Route route);
        void Delete(int id);
    }
    public class RouteService
    {
    }
}
