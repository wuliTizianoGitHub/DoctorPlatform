using System;

namespace DoctorPlatform.Train.Libraries.Domain.Entities.Auditing
{
    /// <summary>
    /// 如果在实体中需要储存<see cref="CreationTime"/>时，那么可以使用这个接口实现。
    /// 当创建<see cref="Entity"/>的时候，<see cref="CreationTime"/>会被自动设置。
    /// </summary>
    public interface IHasCreationTime
    {
        /// <summary>
        /// 当前实体的创建时间
        /// </summary>
        DateTime CreationTime { get; set; }
    }
}
