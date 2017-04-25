using Castle.Core;
using DoctorPlatform.Train.Libraries.Runtime.Session;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Domain.Uow
{
    /// <summary>
    /// 所有工作单元的基类
    /// </summary>
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        public string Id { get; private set; }

        [DoNotWire]
        public IUnitOfWork Outer { get; set; }

        public event EventHandler Completed;

        public event EventHandler<UnitOfWorkFailedEventArgs> Failed;

        public event EventHandler Disposed;

        public UnitOfWorkOptions Options { get; private set; }

        private readonly List<DataFilterConfiguration> _filters;

        public IReadOnlyList<DataFilterConfiguration> Filters { get { return _filters.ToImmutableList(); } }

        /// <summary>
        /// 获取默认的工作单元选项
        /// </summary>
        protected IUnitOfWorkDefaultOptions DefaultOptions { get; }

        /// <summary>
        /// 获取连接字符串解析器
        /// </summary>
        protected IConnectionStringResolver ConnectionStringResolver { get; }

        /// <summary>
        /// 获取一个值表明这个工作单元是否被销毁
        /// </summary>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// 引用当前系统Session
        /// </summary>
        public ISession Session { protected get; set; }

        protected IUnitOfWorkFilterExecuter FilterExecuter { get; }

        /// <summary>
        /// 是否在<see cref="Begin"/>方法调用之前
        /// </summary>
        private bool _isBeginCalledBefore;

        /// <summary>
        /// 是否在<see cref="Complete"/>方法调用之前
        /// </summary>
        private bool _isCompleteCalledBefore;

        /// <summary>
        /// 这个工作单元是否成功完成
        /// </summary>
        private bool _succeed;

        /// <summary>
        /// 如果这个工作单元失败，引用这个异常
        /// </summary>
        private System.Exception _exception;


        protected UnitOfWorkBase(IConnectionStringResolver connectionStringResolver,
            IUnitOfWorkDefaultOptions defaultOptions,
            IUnitOfWorkFilterExecuter filterExecuter)
        {
            FilterExecuter = filterExecuter;
            DefaultOptions = defaultOptions;
            ConnectionStringResolver = connectionStringResolver;

            Id = Guid.NewGuid().ToString("N");
            _filters = defaultOptions.Filters.ToList();
            Session = NullSession.Instance;
        }

        //todo:明天继续

        public void Begin(UnitOfWorkOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            PreventMultipleBegin();
        }

        private void PreventMultipleBegin()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public IDisposable DisableFilter(params string[] filterNames)
        {
            throw new NotImplementedException();
        }

        public IDisposable EnableFilter(params string[] filterNames)
        {
            throw new NotImplementedException();
        }

        public bool IsFilterEnabled(string filterName)
        {
            throw new NotImplementedException();
        }

        public IDisposable SetFilterParameter(string filterName, string parameterName, object value)
        {
            throw new NotImplementedException();
        }

        public void Complete()
        {
            throw new NotImplementedException();
        }

        public Task CompleteAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
