using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_api.Models;
using test_api.Repository;

namespace test_api.Service
{
    // W serwisach powinna być zaimplementowana logika biznesowa (o ile jakaś jest)
    public class LocationService
    {
        // tu też powinno być wstrzykiwane przez DI (jak serwis do kontrolera)
        private LocationRepository locationRepository = new LocationRepository();
        private DeskRepository deskRepository = new DeskRepository();

       
        internal List<Location> GetAllLocations()
        {
            return locationRepository.GetAllLocations();
        }

        internal Location AddLocation(Location location)
        {
            return locationRepository.Add(location);
        }

        internal void DeleteLocation(int id)
        {
            if (deskRepository.DeskExistsInLocation(id))
            {
                // Jeśli istnieje biurko w lokalizacji, to nie może usunąć lokalizacji
                return;
            }
            // Jeśli nie ma biurek w lokalizacji, to może usunąć lokalizację
            locationRepository.Delete(id);
        }
    }
}
