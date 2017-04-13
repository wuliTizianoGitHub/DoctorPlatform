using Castle.Core.Logging;
using DoctorPlatform.Train.Libraries.Dependency;
using DoctorPlatform.Train.Libraries.Modules;
using DoctorPlatform.Train.Tools.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries
{
    /// <summary>
    /// 主类，负责整个系统开始。
    /// 启动时准备依赖注入系统和注册所需要的公共组件。
    /// 它第一次必须初始化和实例化
    /// </summary>
    public class Bootstrapper : IDisposable
    {
        /// <summary>
        /// 在应用程序中获取Startup模块，以及它依赖的其它模块
        /// </summary>
        public Type StartupModule { get; }

        /// <summary>
        /// 获取IIocManager对象以便在此类使用
        /// </summary>
        public IIocManager IocManager { get; }

        /// <summary>
        /// 对象之前是否被销毁
        /// </summary>
        protected bool IsDisposed;

        /// <summary>
        /// 模块管理器
        /// </summary>
        private ModuleManager _moduleManager;

        /// <summary>
        /// 日志
        /// </summary>
        private ILogger _logger;

        private Bootstrapper([NotNull] Type startupModule)
            : this(startupModule, Dependency.IocManager.Instance)
        {

        }

        private Bootstrapper([NotNull] Type startupModule, [NotNull] IIocManager iocManager)
        {

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
