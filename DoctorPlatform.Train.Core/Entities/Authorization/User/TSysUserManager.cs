using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Core.Entities.Authorization.User
{
    public class TSysUserManager : UserManager<TSysUser>
    {
        public TSysUserManager(TSysUserStore store) : base(store)
        {

        }
    }
}
