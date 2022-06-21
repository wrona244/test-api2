using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using test_api.Models;
using test_api.Repository;
using test_api.Service;

namespace test_api.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        // Instancja serwisu powinna być tutaj wstrzykiwana w jakiś sposób, np przez konstruktor (czyt. Inversion Of Controll -> Dependency Injection)
        private LocationService locationService = new LocationService();
        private UserPermissionService userPermissionService = new UserPermissionService();

        [HttpGet]
        public List<Location> GetLocations()
        {
            // zwraca wszystkie lokalizacje
            return locationService.GetAllLocations();
        }

        [HttpPost]
        public Location AddNewLocation(Location location, [FromHeader] long userId)
        {
            // dodane nową lokalizację jeśli użytkownik o podanym id ma uprawnienia administracyjne 
            // (zamiast userId, powinien być jakiś token dla użytkownika wygenerowany za pomocą OAuth2)
            if (!userPermissionService.HasAdminPermission(userId))
            {
                // jeśli nie posiada uprawnień administracyjnych, to tu zamiast null, to powinien zwrócić kod odpowiedzi 'UNAUTHORIZED'
                return null;
            }
            return locationService.AddLocation(location);
        }

        [HttpDelete("{id}")]
        public void DeleteLocation(int id, [FromHeader] long userId)
        {
            if (!userPermissionService.HasAdminPermission(userId))
            {
                // jeśli nie posiada uprawnień administracyjnych, to tu powinien zwrócić kod odpowiedzi 'UNAUTHORIZED'
                return;
            }
            locationService.DeleteLocation(id);
        }
    }
}
