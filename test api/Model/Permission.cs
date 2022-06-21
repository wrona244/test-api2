using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_api.Model
{
    public class Permission
    {
        public long Id { get; set; }
        public String PermissionName { get; set; }

        public Permission(long Id, String PermissionName)
        {
            this.Id = Id;
            this.PermissionName = PermissionName;
        }
    }
}
