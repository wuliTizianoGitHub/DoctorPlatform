using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Domain.Entities
{
    /// <summary>
    /// 用于标记实体 激活/冻结 状态
    /// </summary>
    public interface IPassivable
    {
        /// <summary>
        /// True: 这个实体已激活
        /// False: 这个实体未激活
        /// </summary>
        bool IsActive { get; set; }
    }
}
