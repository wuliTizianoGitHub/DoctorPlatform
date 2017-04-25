using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Runtime.Session
{
    public class NullSession : ISession
    {
        /// <summary>
        /// 单例实例
        /// </summary>
        public static NullSession Instance { get { return SingletonInstance; } }

        private static readonly NullSession SingletonInstance = new NullSession();

        public long? UserId
        {
            get { return null; }
        }

        public long? ImpersonatorUserId
        {
            get { return null; }
        }

        private NullSession()
        {

        }

    }
}
