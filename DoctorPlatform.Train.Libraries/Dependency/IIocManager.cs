using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Dependency
{
    /// <summary>
    /// 用于执行依赖注入
    /// </summary>
    public interface IIocManager : IIocRegistrar, IIocResolver, IDisposable
    {
        /// <summary>
        /// 引用Windsor容器
        /// </summary>
        IWindsorContainer IocContainer { get; }

        /// <summary>
        /// 检查类型在之前是否已注册
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        new bool IsRegistered(Type type);

        /// <summary>
        /// 检查类型在之前是否已注册
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        new bool IsRegistered<T>();
    }
}
