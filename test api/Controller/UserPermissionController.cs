using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_api.Model;
using test_api.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test_api.Controllers
{

    [Route("api/user-permissions")]
    [ApiController]
    public class UserPermissionController : ControllerBase
    {
        private UserPermissionService userPermissionService = new UserPermissionService();

        [HttpPost]
        public UserPermission AddNewUserPermission(UserPermission userPermission)
        {
            return userPermissionService.AddNewUserPermission(userPermission);
        }

        [HttpDelete("{id}")]
        public void DeleteUserPermission(int id)
        {
        }
    }
}
