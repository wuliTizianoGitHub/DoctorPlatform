using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DoctorPlatform.Train.Libraries.Domain.Uow
{
    /// <summary>
    /// 这个标签用于表明，声明方法作为一个工作单元是基元并且应该考虑。这个标签是拦截的方法，会在数据库连接打开并且事务开启之前调用这个方法。
    /// 在方法调用的结束，事务提交，所有的变更也会提交到数据库，前提是这里没有发生异常，否则它会进行回滚。
    /// </summary>
    /// <remarks>
    /// 如果在调用这个方法之前已经有一个工作单元，这个标签将没有效果，这种情况下它会使用相同的事务。
    /// </remarks>
    [AttributeUsage(AttributeTargets.Method)]
    public class UnitOfWorkAttribute : Attribute
    {
        /// <summary>
        /// 范围选项
        /// </summary>
        public TransactionScopeOption? Scope { get; set; }

        /// <summary>
        /// 当前工作单元是否是事务型的？
        /// 如果没有提供则使用默认值。
        /// </summary>
        public bool? IsTransactional { get; set; }

        /// <summary>
        /// 工作单元超时(以毫秒为单位)，如果没有提供则使用默认值。
        /// </summary>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        /// 如果这个工作单元是事务型的，这个选项表明隔离级别为事务，如果没有提供则使用默认值。
        /// </summary>
        public IsolationLevel? IsolationLevel { get; set; }

        /// <summary>
        /// 用于阻止开启工作单元，如果这里已经有一个开启的工作单元，该属性会被忽略，默认值：false。
        /// </summary>
        public bool IsDisabled { get; set; }

        /// <summary>
        /// 创建一个新的<see cref="UnitOfWorkAttribute"/>对象
        /// </summary>
        public UnitOfWorkAttribute()
        {

        }

        /// <summary>
        /// 创建一个新的<see cref="UnitOfWorkAttribute"/>对象
        /// </summary>
        /// <param name="isTransactional">
        /// 这个工作单元是否是事务型的
        /// </param>
        public UnitOfWorkAttribute(bool isTransactional)
        {
            IsTransactional = isTransactional;
        }

        /// <summary>
        /// 创建一个新的<see cref="UnitOfWorkAttribute"/>对象
        /// </summary>
        /// <param name="timeout">以毫秒为单位</param>
        public UnitOfWorkAttribute(int timeout)
        {
            Timeout = TimeSpan.FromMilliseconds(timeout);
        }

        /// <summary>
        /// 创建一个新的<see cref="UnitOfWorkAttribute"/>对象
        /// </summary>
        /// <param name="isTransactional">这个工作单元是否是事务型的</param>
        /// <param name="timeout">以毫秒为单位</param>
        public UnitOfWorkAttribute(bool isTransactional, int timeout)
        {
            IsTransactional = isTransactional;
            Timeout = TimeSpan.FromMilliseconds(timeout);
        }

        /// <summary>
        /// 创建一个新的<see cref="UnitOfWorkAttribute"/>对象。
        /// <see cref="IsTransactional"/> 自动设置为true。
        /// </summary>
        /// <param name="isolationLevel">事务隔离级别</param>
        public UnitOfWorkAttribute(IsolationLevel isolationLevel)
        {
            IsTransactional = true;
            IsolationLevel = isolationLevel;
        }

        /// <summary>
        /// 创建一个新的<see cref="UnitOfWorkAttribute"/>对象。
        /// <see cref="IsTransactional"/> 自动设置为true。
        /// </summary>
        /// <param name="isolationLevel">事务隔离级别</param>
        /// <param name="timeout">事务超时（以毫秒为单位）</param>
        public UnitOfWorkAttribute(IsolationLevel isolationLevel, int timeout)
        {
            IsTransactional = true;
            IsolationLevel = isolationLevel;
            Timeout = TimeSpan.FromMilliseconds(timeout);
        }

        /// <summary>
        /// 创建一个新的<see cref="UnitOfWorkAttribute"/>对象。
        /// <see cref="IsTransactional"/> 自动设置为true。
        /// </summary>
        /// <param name="scope">事务范围</param>
        public UnitOfWorkAttribute(TransactionScopeOption scope)
        {
            IsTransactional = true;
            Scope = scope;
        }

        /// <summary>
        /// 创建一个新的<see cref="UnitOfWorkAttribute"/>对象。
        /// <see cref="IsTransactional"/> 自动设置为true。
        /// </summary>
        /// <param name="scope">事务范围</param>
        /// <param name="timeout"></param>
        public UnitOfWorkAttribute(TransactionScopeOption scope, int timeout)
        {
            IsTransactional = true;
            Scope = scope;
            Timeout = TimeSpan.FromMilliseconds(timeout);
        }

        /// <summary>
        /// 根据方法或者null（如果标签未定义），获取<see cref="UnitOfWorkAttribute"/>标签
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <returns></returns>
        internal static UnitOfWorkAttribute GetUnitOfWorkAttributeOrNull(MemberInfo methodInfo)
        {
            var attrs = methodInfo.GetCustomAttributes(true).OfType<UnitOfWorkAttribute>().ToArray();

            if (attrs.Length > 0)
            {
                return attrs[0];
            }

            if (UnitOfWorkHelper.IsConventionalUowClass(methodInfo.DeclaringType))
            {
                return new UnitOfWorkAttribute(); //默认
            }

            return null;
        }

        internal UnitOfWorkOptions CreateOptions()
        {
            return new UnitOfWorkOptions
            {
                IsTransactional = IsTransactional,
                IsolationLevel = IsolationLevel,
                Timeout = Timeout,
                Scope = Scope
            };
        }
    }
}
