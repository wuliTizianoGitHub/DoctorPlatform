using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Core.Entities.Authorization.Role
{
    public class TSysRoleManager : RoleManager<TSysRole>
    {
        public TSysRoleManager(TSysRoleStore store) : base(store)
        {
            
        }
    }
}
