using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Domain.Uow
{
    /// <summary>
    /// 数据拦截器配置
    /// </summary>
    public class DataFilterConfiguration
    {
        /// <summary>
        /// 拦截器名称
        /// </summary>
        public string FilterName { get; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; }

        /// <summary>
        /// 拦截器参数
        /// </summary>
        public IDictionary<string, object> FilterParameters { get; }

        public DataFilterConfiguration(string filterName, bool isEnabled)
        {
            FilterName = filterName;
            IsEnabled = isEnabled;
            FilterParameters = new Dictionary<string, object>();
        }

        internal DataFilterConfiguration(DataFilterConfiguration filterToClone, bool? isEnabled = null)
            :this(filterToClone.FilterName, isEnabled ?? filterToClone.IsEnabled)
        {
            foreach (var filterParamenter in filterToClone.FilterParameters)
            {
                FilterParameters[filterParamenter.Key] = filterParamenter.Value;
            }
        }
    }
}
