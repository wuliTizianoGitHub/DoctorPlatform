using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DoctorPlatform.Train.Libraries.Domain.Uow
{
    /// <summary>
    /// 用于为工作单元获取/设置默认的选项
    /// </summary>
    public interface IUnitOfWorkDefaultOptions
    {
        /// <summary>
        /// 范围选项
        /// </summary>
        TransactionScopeOption Scope { get; set; }

        /// <summary>
        /// 应为事务型的工作单元，默认为true
        /// </summary>
        bool IsTransactional { get; set; }

        /// <summary>
        /// 获取或者设置工作单元的超时值
        /// </summary>
        TimeSpan? Timeout { get; set; }

        /// <summary>
        /// 用于获取/设置 隔离级别为事务，如果<see cref="IsTransactional"/>为true
        /// </summary>
        IsolationLevel? IsolationLevel { get; set; }

        /// <summary>
        /// 获取所有数据拦截器配置的集合
        /// </summary>
        IReadOnlyList<DataFilterConfiguration> Filters { get; }

        /// <summary>
        /// 注册一个数据拦截器到工作单元系统
        /// </summary>
        /// <param name="filterName">拦截器名称</param>
        /// <param name="isEnabledByDefault">默认启用拦截器</param>
        void RegisterFilter(string filterName, bool isEnabledByDefault);

        /// <summary>
        ///  重写一个数据拦截器定义
        /// </summary>
        /// <param name="filterName">拦截器名称</param>
        /// <param name="isEnabledByDefault">默认启用拦截器</param>
        void OverrideFilter(string filterName, bool isEnabledByDefault);
    }
}
