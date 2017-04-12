using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Dependency
{
    /// <summary>
    /// 用来在Conventional Registration处理中传递所需的对象
    /// </summary>
    internal class ConventionalRegistrationContext : IConventionalRegistrationContext
    {

        public Assembly Assembly { get; private set; }

        public IIocManager IocManager { get; private set; }

        public ConventionalRegistrationConfig Config { get; private set; }

        internal ConventionalRegistrationContext(Assembly assembly, IIocManager iocManager, ConventionalRegistrationConfig config)
        {
            Assembly = assembly;
            IocManager = iocManager;
            Config = config;
        }
    }
}
