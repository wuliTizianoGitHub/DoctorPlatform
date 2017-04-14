using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Domain.Entities.Auditing
{
    /// <summary>
    /// 如果实体需要储存添加信息（当添加时），可以继承此接口来实现。
    /// 当保存<see cref="Entity"/>到数据库时，创建时间以及创建用户会自动设置。
    /// </summary>
    public interface ICreationAudited : IHasCreationTime
    {
        /// <summary>
        /// 当前实体的创建用户ID
        /// </summary>
        long? CreatorUserId { get; set; }
    }


    /// <summary>
    /// 为用户添加导航属性到<see cref="ICreationAudited"/>
    /// </summary>
    /// <typeparam name="TUser">用户类型</typeparam>
    public interface ICreationAudited<TUser> : ICreationAudited
        where TUser : IEntity<long>
    {
        /// <summary>
        /// 引用创建当前实体的用户
        /// </summary>
        TUser CreatorUser { get; set; }
    }
}
