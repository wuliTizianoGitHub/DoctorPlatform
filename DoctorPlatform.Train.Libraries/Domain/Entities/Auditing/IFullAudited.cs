using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Domain.Entities.Auditing
{
    /// <summary>
    /// 该接口实现了IAudited，IDeletionAudited，实体可以进行全部审计
    /// </summary>
    public interface IFullAudited : IAudited, IDeletionAudited
    {

    }

    /// <summary>
    /// 将用户设置为<see cref="IFullAudited"/>的导航属性
    /// </summary>
    /// <typeparam name="TUser">用户类型</typeparam>
    public interface IFullAudited<TUser> : IAudited<TUser>, IFullAudited, IDeletionAudited<TUser>
        where TUser : IEntity<long>
    {

    }
}
