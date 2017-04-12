using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Modules
{
    /// <summary>
    /// 用于管理模块
    /// </summary>
    public class ModuleManager : IModuleManager
    {
        public ModuleInfo StartupModule { get; private set; }

        public IReadOnlyList<ModuleInfo> Modules => _modules.ToImmutableList();
    }
}
