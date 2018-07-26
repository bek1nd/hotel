using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.AppOpinion
{
    public class AppOpinionViewModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Description("编号")]
        public int Id { get; set; }
        /// <summary>
        /// 反馈内容
        /// </summary>
        public string AppOpinion { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int AppType { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        public string CreateTimeDes => CreateTime.ToString("yyyy-MM-dd HH:mm");

        /// <summary>
        /// 提交的客户ID
        /// </summary>
        public int CreateCid { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// 客户公司名称
        /// </summary>
        public string CustomerName { get; set; }


    }
}
