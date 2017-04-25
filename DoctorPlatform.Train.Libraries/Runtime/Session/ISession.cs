using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Runtime.Session
{
    /// <summary>
    /// 定义一些在应用程序中有用的会话信息。
    /// </summary>
    public interface ISession
    {
        /// <summary>
        /// 获取当前用户id或者null，如果没有用户登录，它就是null
        /// </summary>
        long? UserId { get;  }

        /// <summary>
        /// UserId of the impersonator.
        /// This is filled if a user is performing actions behalf of the <see cref="UserId"/>.
        /// </summary>
        long? ImpersonatorUserId { get; }
    }
}
