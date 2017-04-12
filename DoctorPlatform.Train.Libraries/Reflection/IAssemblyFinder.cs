using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Reflection
{
    /// <summary>
    /// 用于获取应用程序中的assembly
    /// </summary>
    public interface IAssemblyFinder
    {
        List<Assembly> GetAllAssemblies();
    }
}
