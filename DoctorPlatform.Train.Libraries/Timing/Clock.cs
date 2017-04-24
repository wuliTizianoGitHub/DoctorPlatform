using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Timing
{
    /// <summary>
    /// 用于平台一些公共日期时间的操作
    /// </summary>
    public static class Clock
    {
        private static IClockProvider _provider;

        /// <summary>
        /// 这个对象用于平台所有的时间操作
        ///  默认值： <see cref="UnspecifiedClockProvider"/>
        /// </summary>
        public static IClockProvider Provider
        {
            get { return _provider; }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Can not set Clock.Provider to null!");
                }

                _provider = value;
            }
        }

        static Clock()
        {
            Provider = ClockProviders.Unspecified;
        }

        /// <summary>
        /// 引用Provider来获取当前时间
        /// </summary>
        public static DateTime Now => Provider.Now;

        /// <summary>
        /// 时间类型
        /// </summary>
        public static DateTimeKind Kind => Provider.Kind;

        /// <summary>
        /// 返回true则支持多个时区，返回false就不支持
        /// </summary>
        public static bool SupportsMultipleTimezone => Provider.SupportsMultipleTimezone;

        /// <summary>
        /// 规范化时间
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime Normalize(DateTime dateTime)
        {
            return Provider.Normalize(dateTime);
        }
    }
}
