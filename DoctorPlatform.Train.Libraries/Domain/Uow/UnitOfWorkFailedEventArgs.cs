using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Domain.Uow
{
    /// <summary>
    /// 在<see cref="IActiveUnitOfWork.Failed"/>事件中作为一个事件参数
    /// </summary>
    public class UnitOfWorkFailedEventArgs : EventArgs
    {
        public System.Exception Exception { get; private set; }

        /// <summary>
        /// 创建一个新的<see cref="UnitOfWorkFailedEventArgs"/>对象
        /// </summary>
        /// <param name="exception">导致失败的异常</param>
        public UnitOfWorkFailedEventArgs(System.Exception exception)
        {
            Exception = exception;
        }
    }
}
