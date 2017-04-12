using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Core.Entities.Authorization.User
{
    public class TSysUserStore : UserStore<TSysUser>
    {
        public TSysUserStore()
        {

        }
    }
}
