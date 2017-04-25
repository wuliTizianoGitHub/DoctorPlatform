using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Domain.Uow
{
    /// <summary>
    /// 用于获取连接字符串，当一个数据库连接需要时。
    /// </summary>
    public interface IConnectionStringResolver
    {
        /// <summary>
        /// 获取一个连接字符串名字（在配置文件中）或者一个完全的连接字符串
        /// </summary>
        /// <param name="args">参数用于解析连接字符串</param>
        /// <returns></returns>
        string GetNameOrConncetionString(ConnectionStringResolveArgs args);
    }
}
