using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Domain.Uow
{
    /// <summary>
    /// 定义一个工作单元，这个接口只在内部使用，使用<see cref="IUnitOfWorkManager.Begin()"/> 来开启一个新的工作单元
    /// </summary>
    public interface IUnitOfWork : IActiveUnitOfWork, IUnitOfWorkCompleteHandle
    {
        /// <summary>
        /// 当前工作单元的唯一ID
        /// </summary>
        string Id { get;}

        /// <summary>
        /// 引用外部的工作单元（如果存在）
        /// </summary>
        IUnitOfWork Outer { get; set; }

        /// <summary>
        /// 提供一些设置开始工作单元
        /// </summary>
        /// <param name="options">工作单元设置</param>
        void Begin(UnitOfWorkOptions options);
    }
}
