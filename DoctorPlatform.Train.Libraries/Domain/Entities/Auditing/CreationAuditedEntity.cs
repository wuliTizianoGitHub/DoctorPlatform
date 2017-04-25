using DoctorPlatform.Train.Libraries.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Domain.Entities.Auditing
{
    /// <summary>
    /// <see cref="CreationAuditedEntity{TPrimaryKey}"/>的快捷方式，主键类型必须为(<see cref="int"/>)
    /// </summary>
    [Serializable]
    public abstract class CreationAuditedEntity : CreationAuditedEntity<int>, IEntity
    {
    }


    /// <summary>
    /// 用于简化实现<see cref="ICreationAudited"/>.
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    [Serializable]
    public abstract class CreationAuditedEntity<TPrimaryKey> : Entity<TPrimaryKey>, ICreationAudited
    {
        /// <summary>
        /// 当前实体的创建时间
        /// </summary>
        public virtual DateTime CreationTime { get; set; }

        /// <summary>
        /// 当前实体的创建者
        /// </summary>
        public virtual long? CreatorUserId { get; set; }

        protected CreationAuditedEntity()
        {
            CreationTime = Clock.Now;
        }
    }


    /// <summary>
    /// 用于简化实现<see cref="ICreationAudited{TUser}"/>
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    /// <typeparam name="TUser"></typeparam>
    [Serializable]
    public abstract class CreationAuditedEntity<TPrimaryKey, TUser> : CreationAuditedEntity<TPrimaryKey>, ICreationAudited<TUser>
         where TUser : IEntity<long>
    {
        /// <summary>
        /// 引用创建当前实体的用户 
        /// </summary>
        [ForeignKey("CreatorUserId")]
        public virtual TUser CreatorUser { get; set; }
    }
}
