using DoctorPlatform.Train.Libraries.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Reflection
{
    public class AssemblyFinder : IAssemblyFinder
    {

        private readonly IModuleManager _moduleManager;


        public AssemblyFinder(IModuleManager moduleMannger)
        {
            _moduleManager = moduleMannger;
        }

        /// <summary>
        /// 获取所有的Assembly
        /// </summary>
        /// <returns></returns>
        public List<Assembly> GetAllAssemblies()
        {
            var assemblies = new List<Assembly>();

            foreach (var module in _moduleManager.Modules)
            {
                assemblies.Add(module.Assembly);

                assemblies.AddRange(module.Instance.GetAdditionalAssemblies());
            }

            return assemblies.Distinct().ToList();
        }
    }
}
