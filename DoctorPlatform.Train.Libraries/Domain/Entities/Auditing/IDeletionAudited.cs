namespace DoctorPlatform.Train.Libraries.Domain.Entities.Auditing
{
    /// <summary>
    /// 如果实体需要储存删除信息（当删除时），可以继承此接口来实现。
    /// </summary>
    public interface IDeletionAudited :IHasDeletionTime
    {
        /// <summary>
        /// 当前实体的删除用户ID
        /// </summary>
        long? DeleterUserId { get; set; }
    }

    /// <summary>
    /// 为用户添加导航属性到<see cref="IDeletionAudited"/>
    /// </summary>
    /// <typeparam name="TUser">用户类型</typeparam>
    public interface IDeletionAudited<TUser> : IDeletionAudited
        where TUser : IEntity<long>
    {
        /// <summary>
        /// 引用删除当前实体的用户
        /// </summary>
        TUser DeleterUser { get; set; }
    }

}
