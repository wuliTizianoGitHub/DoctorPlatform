using System;
using System.Runtime.Serialization;


namespace DoctorPlatform.Train.Libraries.Exception
{
    /// <summary>
    /// 自定义异常基类
    /// </summary>
    [Serializable]
    public class BaseException : System.Exception
    {
        public BaseException() { }

        public BaseException(SerializationInfo serializationInfo, StreamingContext context) : base(serializationInfo, context) { }

        public BaseException(string message) : base(message) { }

        public BaseException(string message, System.Exception innerException) : base(message,innerException) { }
    }
}
