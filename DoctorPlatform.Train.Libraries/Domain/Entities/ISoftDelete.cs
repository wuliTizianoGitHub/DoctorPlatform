using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Domain.Entities
{
    /// <summary>
    /// 软删除接口，用于标准化软删除实体。
    /// 软删除实体实际上不会删除，它依旧存在于数据库中，但被标记为【IsDeleted = true】的状态，程序中并不会去检索该实体。
    /// </summary>
    public interface ISoftDelete
    {
        //用于标记实体为删除状态
        bool IsDeleted { get; set; }
    }
}
