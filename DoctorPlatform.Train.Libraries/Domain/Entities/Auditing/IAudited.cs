using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Domain.Entities.Auditing
{
    /// <summary>
    /// 实体实现了该接口就必须实现审计，
    /// 当<see cref="Entity" />对象正在保存或者更新时，有关系的属性会自动设置。
    /// </summary>
    public interface IAudited : ICreationAudited, IModificationAudited
    {

    }

    /// <summary>
    /// 将用户设置为<see cref="IAudited"/>的导航属性
    /// </summary>
    /// <typeparam name="TUser">用户类型</typeparam>
    public interface IAudited<TUser> : IAudited, ICreationAudited<TUser>, IModificationAudited<TUser>
        where TUser : IEntity<long>
    {

    }
}
