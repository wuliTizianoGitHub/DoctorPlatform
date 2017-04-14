using DoctorPlatform.Train.Libraries.Exception;
using DoctorPlatform.Train.Libraries.Reflection;
using System;

namespace DoctorPlatform.Train.Libraries.Domain.Entities
{
    /// <summary>
    /// 实体帮助类
    /// </summary>
    public static class EntityHelper
    {
        /// <summary>
        /// 检查是否是实体
        /// </summary>
        /// <param name="type">判断类型</param>
        /// <returns></returns>
        public static bool IsEntity(Type type)
        {
            return ReflectionHelper.IsAssignableToGenericType(type, typeof(IEntity<>));
        }

        /// <summary>
        /// （泛型）给予一个实体类型来获取主键
        /// </summary>
        /// <typeparam name="TEntity">泛型实体类型</typeparam>
        /// <returns></returns>
        public static Type GetPrimaryKeyType<TEntity>()
        {
            return GetPrimaryKeyType(typeof(TEntity));
        }

        /// <summary>
        /// 给予一个实体类型来获取主键
        /// </summary>
        /// <param name="entityType">给予的实体类型</param>
        /// <returns></returns>
        public static Type GetPrimaryKeyType(Type entityType)
        {
            foreach (var interfaceType in entityType.GetInterfaces())
            {
                if (interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == typeof(IEntity<>))
                {
                    return interfaceType.GenericTypeArguments[0];
                }
            }
            throw new BaseException("Can not find primary key type of given entity type: " + entityType + ". Be sure that this entity type implements IEntity<TPrimaryKey> interface");
        }
    }
}
