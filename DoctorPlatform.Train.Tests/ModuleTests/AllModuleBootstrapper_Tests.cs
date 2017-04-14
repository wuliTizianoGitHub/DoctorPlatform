using DoctorPlatform.Train.Libraries;
using DoctorPlatform.Train.Libraries.Modules;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DoctorPlatform.Train.Tests.ModuleTests
{
    public class AllModuleBootstrapper_Tests : TestBaseWithLocalIocManager
    {
        [Fact]
        public void  Bootstrapper_ShouldBe_Startup()
        {
            //初始化
            var bootstrapper = Bootstrapper.Create<MyStartupModule>(LocalIocManager);
            bootstrapper.Initialize();

            var modules = bootstrapper.IocManager.Resolve<IModuleManager>().Modules;

            modules.Count.ShouldBe(4);
        }
    }

    [DependsOn(typeof(MyModule1), typeof(MyModule2))]
    public class MyStartupModule : BaseModule { }

    public class MyModule1 : BaseModule { }

    public class MyModule2 : BaseModule { }
}
