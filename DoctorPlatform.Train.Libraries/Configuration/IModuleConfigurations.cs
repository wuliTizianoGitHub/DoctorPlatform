﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Configuration
{
    /// <summary>
    /// 用于提供一些方法给配置模块。
    /// 在这个类创建扩展方法用于<see cref="IStartupConfiguration.Modules"/>对象
    /// </summary>
    public interface IModuleConfigurations
    {
        /// <summary>
        /// 获取配置对象
        /// </summary>
        IStartupConfiguration StartupConfiguration { get; }
    }
}
