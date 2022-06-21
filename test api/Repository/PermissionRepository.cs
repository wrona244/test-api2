using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_api.Model;

namespace test_api.Repository
{
    public class PermissionRepository
    {
        // Uzupełnianie listy ("tabeli") uprawnieniami
        private static List<Permission> Permissions = new List<Permission> {
                        new Permission(1, "Administrator"),
                        new Permission(2, "Employee")};
    }
}
