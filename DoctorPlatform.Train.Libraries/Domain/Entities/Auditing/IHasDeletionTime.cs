using System;

namespace DoctorPlatform.Train.Libraries.Domain.Entities.Auditing
{
    /// <summary>
    /// 如果在实体中需要储存<see cref="DeletionTime"/>时，那么可以使用这个接口实现。
    /// 当删除<see cref="Entity"/>时，<see cref="DeletionTime"/>会被自动设置。
    /// </summary>
    public interface IHasDeletionTime : ISoftDelete
    {
        /// <summary>
        /// 当前实体的删除时间
        /// </summary>
        DateTime? DeletionTime { get; set; }
    }
}
