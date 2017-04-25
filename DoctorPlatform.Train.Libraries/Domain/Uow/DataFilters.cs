using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Domain.Uow
{
    /// <summary>
    /// 标准的拦截器
    /// </summary>
    public static class DataFilters
    {
        /// <summary>
        /// 软删除拦截器，阻止获取数据库中被删除过的数据，查看<see cref="ISoftDelete"/>接口
        /// </summary>
        public const string SoftDelete = "SoftDelete";

    }
}
