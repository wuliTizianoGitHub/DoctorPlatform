using DoctorPlatform.Train.Libraries.Configuration;
using DoctorPlatform.Train.Libraries.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Modules
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class KernelModule : BaseModule
    {
        public override void PreInitialize()
        {
            IocManager.AddConventionalRegistrar(new BasicConventionalRegistrar());

            IocManager.Register<IScopedIocResolver, ScopedIocResolver>(DependencyLifeStyle.Transient);

            //TODO:some registrar...


        }

        public override void Initialize()
        {
            foreach (var replaceAction in ((StartupConfiguration)Configuration).ServiceReplaceActions.Values)
            {
                replaceAction();
            }


            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly(),
                new ConventionalRegistrationConfig
                {
                    InstallInstallers = false
                });
        }

        public override void PostInitialize()
        {
            
        }

        public override void Shutdown()
        {
           
        }
    }
}
