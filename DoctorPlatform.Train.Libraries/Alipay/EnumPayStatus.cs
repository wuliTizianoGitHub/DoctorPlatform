using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Alipay
{
    public enum EnumPayStatus
    {
        /// <summary>
        /// 支付成功
        /// </summary>
        TRADE_SUCCESS = 1,
        /// <summary>
        /// 支付失败
        /// </summary>
        TRADE_ERROR = 2,
        /// <summary>
        /// 验证成功
        /// </summary>
        VERIFY_SUCCESS = 3,

        /// <summary>
        /// 验证失败
        /// </summary>
        VERIFY_ERROR = 4,

        /// <summary>
        /// 有参返回
        /// </summary>
        HAS_PARAMENTER = 5,

        /// <summary>
        /// 无参返回
        /// </summary>
        NO_PARAMENTER = 6

    }
}
