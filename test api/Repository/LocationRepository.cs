using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_api.Models;

namespace test_api.Repository
{
    public class LocationRepository
    {
        // Symuluje tabelę w bazie danych, musi być statyczne, żeby każda instancja odnosiła
        // się do tej samej listy, w przeciwnym wypadku każdy użytkownik łączący się do api
        // miałby osobną "bazę"
        private static List<Location> Locations = new List<Location>();

        public Location Add(Location location)
        {
            // Zwiększaniem ID powinna zajmować się sama baza danych lub framework (np. EntityFramework), jeśli łączylibyśmy się z prawdziwą bazą danych
            long lastId = 0;
            if (Locations.Count > 0)
            {
                // Jeśli jest już jakaś lokacja, to pobiera ostatnie (największe) id
                lastId = Locations.Max(l => l.Id);
            }
            lastId++; // zwiększa id o 1

            location.Id = lastId;   // przypisuje do nowej lokacij

            Locations.Add(location); // dodaje nowa lokację do "bazy"

            return location;    // zwraca nowo utworzoną lokację (wynika to z charakterystyki metody POST (http)
        }

        internal void Delete(int id)
        {
            // Usuwa lokacje o podanym id
            for (int i = 0; i < Locations.Count; i++)
            {
                if (Locations[i].Id == id)
                {
                    Locations.RemoveAt(id);
                    return;
                }
            }
        }

        public List<Location> GetAllLocations()
        {
            return Locations;
        }
    }
}
