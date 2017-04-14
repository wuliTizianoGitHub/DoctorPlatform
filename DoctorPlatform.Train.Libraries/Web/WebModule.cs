using DoctorPlatform.Train.Libraries.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Web
{
    [DependsOn(typeof(KernelModule))]
    public class WebModule : BaseModule
    {
        public override void PreInitialize()
        {
           //注册一些web相关的配置或者组件
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
