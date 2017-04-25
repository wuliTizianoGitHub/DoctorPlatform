using DoctorPlatform.Train.Libraries.Application.Services;
using DoctorPlatform.Train.Libraries.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Domain.Uow
{
    /// <summary>
    /// 工作单元帮助类
    /// </summary>
    internal static class UnitOfWorkHelper
    {
        /// <summary>
        /// 如果工作单元必须根据约定用于给定类型，返回true。
        /// </summary>
        /// <param name="type">需要检查的类型</param>
        /// <returns></returns>
        public static bool IsConventionalUowClass(Type type)
        {
            return typeof(IRepository).IsAssignableFrom(type) || typeof(IApplicationService).IsAssignableFrom(type);
        }

        /// <summary>
        /// 如果给定的方法有<see cref="UnitOfWorkAttribute"/>标签,则返回true。
        /// </summary>
        /// <param name="methodInfo">需要检查的方法信息</param>
        /// <returns></returns>
        public static bool HasUnitOfWorkAttribute(MemberInfo methodInfo)
        {
            return methodInfo.IsDefined(typeof(UnitOfWorkAttribute), true);
        }


        /// <summary>
        /// 返回<see cref="UnitOfWorkAttribute"/>标签（如果包含）。
        /// </summary>
        /// <param name="methodInfo">需要检查的方法信息</param>
        /// <returns></returns>
        public static UnitOfWorkAttribute GetUnitOfWorkAttributeOrNull(MemberInfo methodInfo)
        {
            var attrs = methodInfo.GetCustomAttributes(typeof(UnitOfWorkAttribute), false);
            if (attrs.Length <= 0)
            {
                return null;
            }
            return (UnitOfWorkAttribute)attrs[0];
        }
    }
}
