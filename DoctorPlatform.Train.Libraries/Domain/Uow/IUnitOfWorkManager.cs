using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DoctorPlatform.Train.Libraries.Domain.Uow
{
    /// <summary>
    /// 工作单元管理器。用于开始并且控制一个工作单元
    /// </summary>
    public interface IUnitOfWorkManager
    {
        /// <summary>
        /// 获取当前激活的工作单元（或者空的，如果不存在）
        /// </summary>
        IActiveUnitOfWork Current { get; }

        /// <summary>
        /// 开始一个新的工作单元
        /// </summary>
        /// <returns>一个处理能够完成的工作单元</returns>
        IUnitOfWorkCompleteHandle Begin();

        /// <summary>
        /// 开始一个新的工作单元
        /// </summary>
        /// <returns>一个处理能够完成的工作单元</returns>
        IUnitOfWorkCompleteHandle Begin(TransactionScopeOption scope);

        /// <summary>
        /// 开始一个新的工作单元
        /// </summary>
        /// <returns>一个处理能够完成的工作单元</returns>
        IUnitOfWorkCompleteHandle Begin(UnitOfWorkOptions options);
    }
}
