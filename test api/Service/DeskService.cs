using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_api.Models;
using test_api.Repository;

namespace test_api.Service
{
    public class DeskService
    {
        private DeskRepository deskRepository = new DeskRepository();

        internal Desk AddDesk(Desk desk)
        {
            return deskRepository.Add(desk);
        }

        internal void DeleteDesk(int id)
        {
            deskRepository.Delete(id);
        }
    }
}
