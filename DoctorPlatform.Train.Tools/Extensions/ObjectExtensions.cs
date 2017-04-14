using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Tools.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// 用于转换对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T As<T>(this object obj)
             where T : class
        {
            return (T)obj;
        }
    }
}
