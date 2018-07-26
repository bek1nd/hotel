using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Flight
{
    public class AddRetApplyRequestViewModel : RequestBaseViewModel
    {
        public string IsOnline { get; set; } = "F";
        public string CorpId { get; set; }
        public int OrderId { get; set; }

        /// <summary>
        /// 联系人名称
        /// </summary>
        [Required]
        public string ContactName { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [Required]
        public string ContactTel { get; set; }

        /// <summary>
        /// 申请原因
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 服务费
        /// </summary>
        public decimal ServiceFee { get; set; }
        /// <summary>
        /// 文件上传路径
        /// </summary>
        public string UploadUrl { get; set; }
        /// <summary>
        /// 申请明细
        /// </summary>
        public List<AddRetApplyDetailViewModel> DetailList { get; set; }
    }
}
