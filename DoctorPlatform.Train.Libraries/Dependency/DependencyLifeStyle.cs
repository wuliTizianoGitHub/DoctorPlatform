using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Dependency
{

    /// <summary>
    /// 在依赖注入系统中使用类型的LifeStyle
    /// </summary>
    public enum DependencyLifeStyle
    {
        /// <summary>
        /// 单例对象，被创建的对象会在第一次进行解析，并且后续可以使用这个实例
        /// </summary>
        Singleton,
        /// <summary>
        /// 短暂对象，每次解析会重新创建
        /// </summary>
        Transient
    }
}
