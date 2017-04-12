using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Exception
{
    /// <summary>
    /// 如果问题出在initialization处理中，则抛出这个异常
    /// </summary>
    [Serializable]
    public class InitializationException :BaseException
    {
        public InitializationException()
        {

        }

        public InitializationException(SerializationInfo serializationInfo, StreamingContext context)
            :base(serializationInfo,context)
        {

        }

        public InitializationException(string message)
            :base(message)
        {

        }

        public InitializationException(string message, System.Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
