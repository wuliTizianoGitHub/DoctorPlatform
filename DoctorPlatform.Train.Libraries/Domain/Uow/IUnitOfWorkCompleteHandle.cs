using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Domain.Uow
{
    /// <summary>
    /// 用于完成一个工作单元，这个接口不能被注入或者直接使用，使用<see cref="IUnitOfWorkManager"/> 代替。
    /// </summary>
    public interface IUnitOfWorkCompleteHandle : IDisposable
    {
        /// <summary>
        /// 完成当前工作单元。如果存在，它保存所有的更改并提交事务。
        /// </summary>
        void Complete();

        /// <summary>
        /// （异步）完成当前工作单元。如果存在，它保存所有的更改并提交事务。
        /// </summary>
        /// <returns></returns>
        Task CompleteAsync();
    }
}
