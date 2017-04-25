using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DoctorPlatform.Train.Libraries.Domain.Uow
{
    /// <summary>
    /// 工作单元的设置
    /// </summary>
    public class UnitOfWorkOptions
    {
        /// <summary>
        /// 范围设置
        /// </summary>
        public TransactionScopeOption? Scope { get; set; }


        /// <summary>
        /// 当前工作单元是否为事务型的，如果没有提供，则使用默认值
        /// </summary>
        public bool? IsTransactional { get; set; }

        /// <summary>
        /// 工作单元超时（毫秒级），如果没有提供，则使用默认值
        /// </summary>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        /// 如果当前工作单元是事务型的，这个设置表明隔离级别为事务，如果没有提供，则使用默认值
        /// </summary>
        public IsolationLevel? IsolationLevel { get; set; }

        /// <summary>
        /// 这个设置应该设为<see cref="TransactionScopeAsyncFlowOption.Enabled"/>，如果工作单元用于async scope（异步范围）中
        /// </summary>
        public TransactionScopeAsyncFlowOption? AsyncFlowOption { get; set; }

        /// <summary>
        /// 用于启用或者禁用一些拦截器
        /// </summary>
        public List<DataFilterConfiguration> FilterOverrides { get; private set; }

        public UnitOfWorkOptions()
        {
            FilterOverrides = new List<DataFilterConfiguration>();
        }

        internal void FilDefaultsForNonProvidedOptions(IUnitOfWorkDefaultOptions defaultOptions)
        {
            //todo : 改变设置中的对象
            if (!IsTransactional.HasValue)
            {
                IsTransactional = defaultOptions.IsTransactional;
            }

            if (!Scope.HasValue)
            {
                Scope = defaultOptions.Scope;
            }

            if (!Timeout.HasValue && defaultOptions.Timeout.HasValue)
            {
                Timeout = defaultOptions.Timeout.Value;
            }

            if (!IsolationLevel.HasValue && defaultOptions.IsolationLevel.HasValue)
            {
                IsolationLevel = defaultOptions.IsolationLevel.Value;
            }
        }
    }
}
