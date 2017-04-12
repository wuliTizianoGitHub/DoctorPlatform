using DoctorPlatform.Train.Core.Entities.Authorization.User;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Core.Entities.Authorization.Role
{
    public class TSysRole : IdentityRole
    {

        public virtual string DisplayName { get; set; }

        public virtual string Description { get; set; }

        public virtual bool IsDefault { get; set; }

        public virtual bool IsStatic { get; set; }

        public virtual TSysUser CreatorUser { get; set; }

        public virtual TSysUser DeleterUser { get; set; }

        public virtual TSysUser LastModifierUser { get; set; }
    }
}
