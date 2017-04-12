using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Dependency
{
    /// <summary>
    /// 用于注册基本依赖实现，比如 <see cref="ITransientDependency"/> 和 <see cref="ISingletonDependency"/>
    /// </summary>
    public class BasicConventionalRegistrar : IConventionalDependencyRegistrar
    {
        public void RegisterAssembly(IConventionalRegistrationContext context)
        {
            //Transient
            context.IocManager.IocContainer.Register(
                Classes.FromAssembly(context.Assembly)
                .IncludeNonPublicTypes()
                .BasedOn<ITransientDependency>()
                .WithService.Self()
                .WithService.DefaultInterfaces()
                .LifestyleTransient()
                );

            //Singleton 
            context.IocManager.IocContainer.Register(
                 Classes.FromAssembly(context.Assembly)
                .IncludeNonPublicTypes()
                .BasedOn<ISingletonDependency>()
                .WithService.Self()
                .WithService.DefaultInterfaces()
                .LifestyleSingleton()
                );

            //Windsor Interceptors
            context.IocManager.IocContainer.Register(
                Classes.FromAssembly(context.Assembly)
                    .IncludeNonPublicTypes()
                    .BasedOn<IInterceptor>()
                    .WithService.Self()
                    .LifestyleTransient()
                );
        }
    }
}
