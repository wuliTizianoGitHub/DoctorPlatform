using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Dependency
{
    /// <summary>
    /// 用于注册依赖
    /// </summary>
    public interface IConventionalDependencyRegistrar
    {
        /// <summary>
        /// 注册Assembly
        /// </summary>
        /// <param name="context"></param>
        void RegisterAssembly(IConventionalRegistrationContext context);


    }
}
