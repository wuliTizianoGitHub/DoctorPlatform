using DoctorPlatform.Train.Tools.Extensions;
using DoctorPlatform.Train.Libraries.Domain.Entities.Auditing;

namespace DoctorPlatform.Train.Libraries.Domain.Entities
{
    public static class EntityExtensions
    {
        /// <summary>
        /// 检查这个实体是否为空或者被删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool IsNullOrDeleted(this ISoftDelete entity)
        {
            return entity == null || entity.IsDeleted;
        }

        /// <summary>
        /// 取消删除这个实体，设置 <see cref="ISoftDelete.IsDeleted"/> 为false，并且设置<see cref="IDeletionAudited"/>属性为null
        /// </summary>
        /// <param name="entity"></param>
        public static void UnDelete(this ISoftDelete entity)
        {
            entity.IsDeleted = false;
            if (entity is IDeletionAudited)
            {
                var deletionAuditedEntity = entity.As<IDeletionAudited>();
                deletionAuditedEntity.DeletionTime = null;
                deletionAuditedEntity.DeleterUserId = null;
            }
        }
    }
}
