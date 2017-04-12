using DoctorPlatform.Train.Core.Entities.Authorization.Role;
using DoctorPlatform.Train.Core.Entities.Authorization.User;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.EntityFramework.EntityFramework
{
    public class TrainDbContext: IdentityDbContext
    {
        public TrainDbContext():
            base("TrainDb")
        {

        }

        public virtual IDbSet<TSysUser> TSysUsers { get; set; }

        public virtual IDbSet<TSysRole> TSysRoles { get; set; }


        static TrainDbContext()
        {
            //初始化种子数据
            Database.SetInitializer<TrainDbContext>(null);
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //TODO:设置实体映射
            base.OnModelCreating(modelBuilder);
        }

        //public static TrainDbContext Create()
        //{
        //    return new TrainDbContext();
        //}
    }
}
