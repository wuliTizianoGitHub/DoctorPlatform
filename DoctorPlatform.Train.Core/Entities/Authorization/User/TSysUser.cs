using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Core.Entities.Authorization.User
{
    public class TSysUser : IdentityUser
    {
        public virtual string Surname { get; set; }

        public virtual TSysUser CreatorUser { get; set; }

        public virtual TSysUser DeleterUser { get; set; }

        public virtual TSysUser LastModifierUser { get; set; }
    }
}
