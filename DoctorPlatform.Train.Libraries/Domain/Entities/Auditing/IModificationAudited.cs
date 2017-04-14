using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Domain.Entities.Auditing
{
    /// <summary>
    /// 如果实体需要储存修改信息（当修改时），可以继承此接口来实现。
    /// 当保存<see cref="Entity"/>到数据库时，修改时间以及修改用户会自动设置。
    /// </summary>
    public interface IModificationAudited:IHasModificationTime
    {
        /// <summary>
        /// 
        /// </summary>
        long? LastModifierUserId { get; set; }
}
}

