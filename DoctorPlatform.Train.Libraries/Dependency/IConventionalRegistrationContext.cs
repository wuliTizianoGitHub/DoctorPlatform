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
    public interface IConventionalRegistrationContext
    {
        /// <summary>
        /// 获取注册的程序集
        /// </summary>
        Assembly Assembly { get; }

        /// <summary>
        /// 引用IOC容器
        /// </summary>
        IIocManager IocManager { get; }

        /// <summary>
        /// 注册配置
        /// </summary>
        ConventionalRegistrationConfig Config { get; }
    }
}
