using DoctorPlatform.Train.Libraries.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Dependency
{
    /// <summary>
    /// 注册配置
    /// </summary>
    public class ConventionalRegistrationConfig : DictionaryBasedConfig
    {
        /// <summary>
        /// 自动安装所有的IInterceptor实现，默认为true
        /// </summary>
        public bool InstallInstallers { get; set; }

        public ConventionalRegistrationConfig()
        {
            InstallInstallers = true;
        }
    }
}
