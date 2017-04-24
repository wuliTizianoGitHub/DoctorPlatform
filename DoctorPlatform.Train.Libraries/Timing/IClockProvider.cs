using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Timing
{
    public interface IClockProvider
    {
        /// <summary>
        /// 获取当前时间
        /// </summary>
        DateTime Now { get; }

        /// <summary>
        /// 时间类型
        /// </summary>
        DateTimeKind Kind { get; }

        /// <summary>
        /// 是否支持多个时区
        /// </summary>
        bool SupportsMultipleTimezone { get; }

        /// <summary>
        /// 规范化时间
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        DateTime Normalize(DateTime dateTime);
    }
}
