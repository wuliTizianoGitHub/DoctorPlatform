using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Domain.Entities.Auditing
{
    /// <summary>
    /// <see cref="FullAuditedEntity{TPrimaryKey}"/>的快捷方式，主键类型必须是(<see cref="int"/>)。
    /// </summary>
    [Serializable]
    public abstract class FullAuditedEntity : FullAuditedEntity<int>, IEntity
    {

    }

    /// <summary>
    /// 实现了<see cref="IFullAudited"/>的实体类可以进行完全审计
    /// </summary>
    /// <typeparam name="TPrimaryKey">实体主键类型</typeparam>
    [Serializable]
    public abstract class FullAuditedEntity<TPrimaryKey> : AuditedEntity<TPrimaryKey>, IFullAudited
    {
        /// <summary>
        /// 实体是否被删除
        /// </summary>
        public virtual bool IsDeleted { get; set; }

        /// <summary>
        /// 删除当前实体的用户
        /// </summary>
        public virtual long? DeleterUserId { get; set; }

        /// <summary>
        /// 当前实体的删除时间
        /// </summary>
        public virtual DateTime? DeletionTime { get; set; }
    }

    /// <summary>
    /// 实现了<see cref="IFullAudited{TUser}"/>的实体类可以进行完全审计
    /// </summary>
    /// <typeparam name="TPrimaryKey">实体主键类型</typeparam>
    /// <typeparam name="TUser">用户类型</typeparam>
    [Serializable]
    public abstract class FullAuditedEntity<TPrimaryKey, TUser> : AuditedEntity<TPrimaryKey, TUser>, IFullAudited<TUser>
        where TUser : IEntity<long>
    {
        /// <summary>
        /// 实体是否被删除
        /// </summary>
        public virtual bool IsDeleted { get; set; }

        /// <summary>
        /// 引用删除当前实体的用户
        /// </summary>
        [ForeignKey("DeleterUserId")]
        public virtual TUser DeleterUser { get; set; }

        /// <summary>
        /// 删除当前实体的用户
        /// </summary>
        public virtual long? DeleterUserId { get; set; }

        /// <summary>
        /// 当前实体的删除时间
        /// </summary>
        public virtual DateTime? DeletionTime { get; set; }
    }
}
