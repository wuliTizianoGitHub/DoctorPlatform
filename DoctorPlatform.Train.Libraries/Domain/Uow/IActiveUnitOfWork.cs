using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Domain.Uow
{
    /// <summary>
    /// 用于激活工作单元，该接口不会被注入，使用<see cref="IUnitOfWorkManager"/>代替
    /// </summary>
    public interface IActiveUnitOfWork
    {
        /// <summary>
        /// 当前工作单元成功的完成之后的事件
        /// </summary>
        event EventHandler Completed;

        /// <summary>
        /// 当前工作单元失败之后的事件
        /// </summary>
        event EventHandler<UnitOfWorkFailedEventArgs> Failed;

        /// <summary>
        /// 当前工作单元被销毁之后的事件
        /// </summary>
        event EventHandler Disposed;

        /// <summary>
        /// 如果当前工作单元是事务就获取
        /// </summary>
        UnitOfWorkOptions Options { get; }

        /// <summary>
        /// 为当前工作单元获取数据拦截器配置
        /// </summary>
        IReadOnlyList<DataFilterConfiguration> Filters { get; }

        /// <summary>
        /// 当前工作单元是否被销毁
        /// </summary>
        bool IsDisposed { get; }

        /// <summary>
        /// 在当前工作单元中保存直到现在为止所有变更，调用这个方法可能是申请变更时需要的。
        /// 注意,如果这是事务性的工作单元， 那么事务在进行回滚时，保存变更也是回滚。
        /// 通常不需要显式的调用SaveChanges，因为所有的变更保存都会在工作单元结束之后自动进行。
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// （异步）在当前工作单元中保存直到现在为止所有变更，调用这个方法可能是申请变更时需要的。
        /// 注意,如果这是事务性的工作单元， 那么事务在进行回滚时，保存变更也是回滚。
        /// 通常不需要显式的调用SaveChanges，因为所有的变更保存都会在工作单元结束之后自动进行。
        /// </summary>
        Task SaveChangesAsync();

        /// <summary>
        /// 禁用一个或者更多数据拦截器。如果它已经禁用，则没有一个拦截器。如果你需要，使用这个方法在一个引用声明中重新启用拦截器。
        /// </summary>
        /// <param name="filterNames">一个或者更多拦截器的名称，<see cref="DataFilters"/>标准过滤器</param>
        /// <returns>一个<see cref="IDisposable"/>处理，收回禁用的效果</returns>
        IDisposable DisableFilter(params string[] filterNames);

        /// <summary>
        /// 启用一个或者更多数据拦截器。如果它已经启用，则没有一个拦截器。如果你需要，使用这个方法在一个引用声明中重新禁用拦截器。
        /// </summary>
        /// <param name="filterNames">一个或者更多拦截器的名称，<see cref="DataFilters"/>标准过滤器</param>
        /// <returns>一个<see cref="IDisposable"/>处理，收回启用的效果</returns>
        IDisposable EnableFilter(params string[] filterNames);

        /// <summary>
        /// 检查拦截器是否启用
        /// </summary>
        /// <param name="filterName">拦截器名称，<see cref="DataFilters"/>标准过滤器</param>
        /// <returns></returns>
        bool IsFilterEnabled(string filterName);

        /// <summary>
        /// 设置（重写）一个拦截器参数的值
        /// </summary>
        /// <param name="filterName">拦截器名称</param>
        /// <param name="parameterName">参数名称</param>
        /// <param name="value">设置的参数值</param>
        /// <returns></returns>
        IDisposable SetFilterParameter(string filterName, string parameterName, object value);
    }
}
