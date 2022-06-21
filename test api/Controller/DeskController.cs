using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_api.Models;
using test_api.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test_api.Controller
{
    [Route("api/desks")]
    [ApiController]
    public class DeskController : ControllerBase
    {
        private DeskService deskService = new DeskService();

        [HttpPost]
        public Desk AddDesk(Desk desk)
        {
            return deskService.AddDesk(desk);
        }

        [HttpDelete("{id}")]
        public void DeleteDesk(int id)
        {
            deskService.DeleteDesk(id);
        }
    }
}
