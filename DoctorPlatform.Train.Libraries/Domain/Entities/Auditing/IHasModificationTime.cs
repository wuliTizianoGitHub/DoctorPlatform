using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Domain.Entities.Auditing
{
    /// <summary>
    /// 如果在实体中需要储存<see cref="LastModificationTime"/>时，那么可以使用这个接口实现。
    /// 当修改<see cref="Entity"/>时，<see cref="LastModificationTime"/>会被自动设置。
    /// </summary>
    public interface IHasModificationTime
    {
        /// <summary>
        /// 当前实体的最后修改时间
        /// </summary>
        DateTime? LastModificationTime { get; set; }
    }
}
