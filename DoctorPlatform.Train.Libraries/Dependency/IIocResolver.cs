using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Dependency
{
    /// <summary>
    /// 在类中解析依赖
    /// </summary>
    public interface IIocResolver
    {
        /// <summary>
        /// 从IOC容器中获取一个对象，返回对象必须在释放之前使用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>对象实例</returns>
        T Resolve<T>();

        /// <summary>
        /// 从IOC容器中获取一个对象，返回对象必须在释放之前使用（通过传递进来的类型解析）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns>对象实例</returns>
        T Resolve<T>(Type type);

        /// <summary>
        /// 从IOC容器中获取一个对象，返回对象必须在释放之前使用（通过传递进来的匿名类型解析）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argumentsAsAnonymousTypes"></param>
        /// <returns></returns>
        T Resolve<T>(object argumentsAsAnonymousTypes);

        /// <summary>
        /// 从IOC容器中获取一个对象，返回对象必须在释放之前使用
        /// </summary>
        /// <param name="type"></param>
        /// <returns>返回Object实例</returns>
        object Resolve(Type type);

        /// <summary>
        /// 从IOC容器中获取一个对象，返回对象必须在释放之前使用
        /// </summary>
        /// <param name="type"></param>
        /// <param name="argumentsAsAnonymousType"></param>
        /// <returns></returns>
        object Resolve(Type type, object argumentsAsAnonymousType);

        /// <summary>
        /// 获取类型的所有实现
        /// </summary>
        /// <returns></returns>
        T[] ResolveAll<T>();

        /// <summary>
        /// 获取类型的所有实现
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argumentsAsAnonymousType"></param>
        /// <returns></returns>
        T[] ResolveAll<T>(object argumentsAsAnonymousType);

        /// <summary>
        /// 根据类型获取所有的实现
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        object[] ResolveAll(Type type);

        /// <summary>
        /// 根据类型获取所有的实现
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        object[] ResolveAll(Type type, object argumentsAsAnonymousType);

        /// <summary>
        /// 释放解析过的对象
        /// </summary>
        /// <param name="obj"></param>
        void Release(object obj);

        /// <summary>
        /// 是否注册
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        bool IsRegistered(Type type);

        /// <summary>
        /// 是否注册
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        bool IsRegistered<T>();


    }
}
