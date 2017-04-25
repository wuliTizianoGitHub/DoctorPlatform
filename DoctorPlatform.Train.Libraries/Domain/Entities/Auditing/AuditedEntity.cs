using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Domain.Entities.Auditing
{
    /// <summary>
    /// <see cref="AuditedEntity{TPrimaryKey}"/>的快捷方式，主键类型必须是(<see cref="int"/>)。
    /// </summary>
    [Serializable]
    public abstract class AuditedEntity : AuditedEntity<int>, IEntity
    {

    }

    /// <summary>
    /// 用于简化实现<see cref="IAudited"/>
    /// </summary>
    /// <typeparam name="TPrimaryKey">实体主键类型</typeparam>
    [Serializable]
    public abstract class AuditedEntity<TPrimaryKey> : CreationAuditedEntity<TPrimaryKey>, IAudited
    {
        /// <summary>
        /// 当前实体最后修改时间
        /// </summary>
        public virtual DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// 当前实体最后修改人
        /// </summary>
        public virtual long? LastModifierUserId { get; set; }
    }

    /// <summary>
    /// 用于简化实现<see cref="IAudited{TUser}"/>
    /// </summary>
    /// <typeparam name="TPrimaryKey">实体主键类型</typeparam>
    /// <typeparam name="TUser">用户类型</typeparam>
    [Serializable]
    public abstract class AuditedEntity<TPrimaryKey, TUser> : AuditedEntity<TPrimaryKey>, IAudited<TUser>
         where TUser : IEntity<long>
    {
        /// <summary>
        /// 引用创建当前实体的用户
        /// </summary>
        [ForeignKey("CreatorUserId")]
        public virtual TUser CreatorUser { get; set; }

        /// <summary>
        ///  引用最后修改当前实体的用户
        /// </summary>
        [ForeignKey("LastModifierUserId")]
        public virtual TUser LastModifierUser { get; set; }
    }
}
