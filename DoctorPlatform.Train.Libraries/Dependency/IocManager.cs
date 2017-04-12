using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Dependency
{
    /// <summary>
    /// 用于执行依赖注入
    /// </summary>
    public class IocManager : IIocManager
    {
        /// <summary>
        /// 单例实例
        /// </summary>
        public static IocManager Instance { get; private set; }

        /// <summary>
        /// Windsor容器
        /// </summary>
        public IWindsorContainer IocContainer { get; private set; }

        /// <summary>
        /// 注册过的注册者集合
        /// </summary>
        private readonly List<IConventionalDependencyRegistrar> _conventionalRegistrars;


        static IocManager()
        {
            Instance = new IocManager();
        }

        /// <summary>
        /// 创建一个新的 <see cref="IocManager"/>对象
        /// </summary>
        public IocManager()
        {
            IocContainer = new WindsorContainer();
            _conventionalRegistrars = new List<IConventionalDependencyRegistrar>();

            //注册自身
            IocContainer.Register(
                Component.For<IocManager, IIocManager, IIocRegistrar, IIocResolver>().UsingFactoryMethod(() => this)
                );
        }

        /// <summary>
        /// 添加依赖注册者
        /// </summary>
        /// <param name="registrar"></param>
        public void AddConventionalRegistrar(IConventionalDependencyRegistrar registrar)
        {
            _conventionalRegistrars.Add(registrar);
        }

        /// <summary>
        /// 提供assembly来注册类型
        /// </summary>
        /// <param name="assembly"></param>
        public void RegisterAssemblyByConvention(Assembly assembly)
        {
            RegisterAssemblyByConvention(assembly, new ConventionalRegistrationConfig());
        }

        /// <summary>
        /// 提供assembly来注册类型
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="config"></param>
        public void RegisterAssemblyByConvention(Assembly assembly, ConventionalRegistrationConfig config)
        {
            //实例化Conventional Registration上下文
            var context = new ConventionalRegistrationContext(assembly, this, config);

            foreach (var _register in _conventionalRegistrars)
            {
                //将上下文添加到每一个注册者中
                _register.RegisterAssembly(context);
            }

            if (config.InstallInstallers)
            {
                //如果配置已安装，就安装assembly实例到IOC容器
                IocContainer.Install(FromAssembly.Instance(assembly));
            }
        }

        /// <summary>
        /// 注册类型
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="lifesytle"></param>
        public void Register<TType>(DependencyLifeStyle lifesytle = DependencyLifeStyle.Singleton) where TType : class
        {
            IocContainer.Register(ApplyLifeStyle(Component.For<TType>(), lifesytle));
        }

        /// <summary>
        /// 注册类型
        /// </summary>
        /// <param name="type"></param>
        /// <param name="lifesytle"></param>
        public void Register(Type type,DependencyLifeStyle lifesytle = DependencyLifeStyle.Singleton)
        {
            IocContainer.Register(ApplyLifeStyle(Component.For(type), lifesytle));
        }

        /// <summary>
        /// 注册类型以及它的实现
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <typeparam name="TImpl"></typeparam>
        /// <param name="lifeStyle"></param>
        public void Register<TType,TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where TType :class
            where TImpl : class  ,TType
        {
            IocContainer.Register(ApplyLifeStyle(Component.For<TType, TImpl>().ImplementedBy<TImpl>(), lifeStyle));
        }

        public void Register(Type type, Type impl, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            IocContainer.Register(ApplyLifeStyle(Component.For(type, impl).ImplementedBy(impl), lifeStyle));
        }

        /// <summary>
        /// 检查类型是否已经注册到容器中
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool IsRegistered(Type type)
        {
            return IocContainer.Kernel.HasComponent(type);
        }

        public bool IsRegistered<TType>()
        {
            return IocContainer.Kernel.HasComponent(typeof(TType));
        }

        /// <summary>
        ///  从IOC容器中获取一个对象，返回对象必须在释放之前使用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Resolve<T>()
        {
            return IocContainer.Resolve<T>();
        }

        /// <summary>
        /// 从IOC容器中获取一个对象，返回对象必须在释放之前使用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T Resolve<T>(Type type)
        {
            return (T)IocContainer.Resolve(type);
        }


        /// <summary>
        /// 从IOC容器中获取一个对象，返回对象必须在释放之前使用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argumentsAsAnonymousTypes"></param>
        /// <returns></returns>
        public T Resolve<T>(object argumentsAsAnonymousTypes)
        {
            return IocContainer.Resolve<T>(argumentsAsAnonymousTypes);
        }


        public object Resolve(Type type)
        {
            return IocContainer.Resolve(type);
        }

        public object Resolve(Type type, object argumentsAsAnonymousType)
        {
            return IocContainer.Resolve(type,argumentsAsAnonymousType);
        }


        public T[] ResolveAll<T>()
        {
            return IocContainer.ResolveAll<T>();
        }

        public T[] ResolveAll<T>(object argumentsAsAnonymousType)
        {
            return IocContainer.ResolveAll<T>(argumentsAsAnonymousType);
        }

        public object[] ResolveAll(Type type)
        {
            return IocContainer.ResolveAll(type).Cast<object>().ToArray();
        }

        public object[] ResolveAll(Type type, object argumentsAsAnonymousType)
        {
            return IocContainer.ResolveAll(type, argumentsAsAnonymousType).Cast<object>().ToArray();
        }

        public void Release(object obj)
        {
            IocContainer.Release(obj);
        }

        public void Dispose()
        {
            IocContainer.Dispose();
        }


        /// <summary>
        /// 应用生命周期类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="registration"></param>
        /// <param name="lifeStyle"></param>
        /// <returns></returns>
        private static ComponentRegistration<T> ApplyLifeStyle<T>(ComponentRegistration<T> registration, DependencyLifeStyle lifeStyle)
            where T : class
        {
            switch (lifeStyle)
            {
                case DependencyLifeStyle.Transient:
                    return registration.LifestyleTransient();
                case DependencyLifeStyle.Singleton:
                    return registration.LifestyleSingleton();
                default:
                    return registration;
            }
        }
    }
}
