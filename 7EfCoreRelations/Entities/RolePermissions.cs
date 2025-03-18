using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreRelations.Entities
{
    public class RolePermissions
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        public Permission Permission { get; set; }
        public Role Role { get; set; }
    }
}