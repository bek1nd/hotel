using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.BaseMaintenance
{
    public class Tra12306AccountModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int PassId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 使用人
        /// </summary>
        public string UserOid { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public string IsDel { get; set; }
    }
}
