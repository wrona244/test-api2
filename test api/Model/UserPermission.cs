using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_api.Model
{
    public class UserPermission
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long PermissionId { get; set; }

        public UserPermission(long Id, long UserId, long PermissionId)
        {
            this.Id = Id;
            this.UserId = UserId;
            this.PermissionId = PermissionId;
        }
    }
}
