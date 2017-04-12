using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Dependency
{
    /// <summary>
    /// 用于注册依赖
    /// </summary>
    public interface IIocRegistrar
    {
        /// <summary>
        /// 添加一个依赖注册者
        /// </summary>
        /// <param name="registrar"></param>
        void AddConventionalRegistrar(IConventionalDependencyRegistrar registrar);

        /// <summary>
        /// 提供Assembly来注册类型
        /// </summary>
        /// <param name="assembly"></param>
        void RegisterAssemblyByConvention(Assembly assembly);


        /// <summary>
        /// 根据配置，提供Assembly来注册类型
        /// </summary>
        /// <param name="assembly"></param>
        void RegisterAssemblyByConvention(Assembly assembly, ConventionalRegistrationConfig config);

        /// <summary>
        /// 注册自身
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lifeStyle"></param>
        void Register<T>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
           where T : class;

        /// <summary>
        /// 注册自身
        /// </summary>
        /// <param name="type"></param>
        /// <param name="lifeStyle"></param>
        void Register(Type type, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton);

        /// <summary>
        /// 注册一个类型以及它的实现
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <typeparam name="TImpl"></typeparam>
        /// <param name="lifeStyle"></param>
        void Register<TType, TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where TType : class
            where TImpl : class, TType;


        /// <summary>
        /// 注册一个类型以及它的实现
        /// </summary>
        /// <param name="type"></param>
        /// <param name="impl"></param>
        /// <param name="lifeStyle"></param>
        void Register(Type type, Type impl, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton);

        /// <summary>
        /// 检查是否已注册
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        bool IsRegistered(Type type);

        /// <summary>
        /// 检查是否已注册
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <returns></returns>
        bool IsRegistered<TType>();
    }
}
