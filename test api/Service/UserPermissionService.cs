using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_api.Model;
using test_api.Repository;

namespace test_api.Service
{
    public class UserPermissionService
    {
        private UserPermissionRepository userPermissionRepository = new UserPermissionRepository();
        internal bool HasAdminPermission(long userId)
        {
            return userPermissionRepository.HasAdminPermission(userId);
        }

        internal UserPermission AddNewUserPermission(UserPermission userPermission)
        {
            return userPermissionRepository.Add(userPermission);
        }
    }
}
