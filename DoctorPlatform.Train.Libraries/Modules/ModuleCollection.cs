using DoctorPlatform.Train.Libraries.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Modules
{
    /// <summary>
    /// 用于存储ModuleInfo对象到dictionary集合中
    /// </summary>
    public class ModuleCollection : List<ModuleInfo>
    {
        public Type StartupModuleType { get; }

        public ModuleCollection(Type startupModuleType)
        {
            StartupModuleType = startupModuleType;
        }

        /// <summary>
        /// 获取模块实例
        /// </summary>
        /// <typeparam name="TModule"></typeparam>
        /// <returns></returns>
        public TModule GetModule<TModule>()
            where TModule : BaseModule
        {
            var module = this.FirstOrDefault(m => m.Type == typeof(TModule));
            if (module == null)
            {
                throw new BaseException("Can not find module for " + typeof(TModule).FullName);
            }

            return (TModule)module.Instance;
        }

        /// <summary>
        /// 分类模块相符的依赖
        /// 如果模块A依赖于模块B，
        /// </summary>
        /// <returns></returns>
        public List<ModuleInfo> GetSortedModuleListByDependency()
        {

        }
    }
}
