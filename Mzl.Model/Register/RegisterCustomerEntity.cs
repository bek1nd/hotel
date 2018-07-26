using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Register
{
    /// <summary>
    /// 合作登记
    /// </summary>
    [Table("P_RegisterCustomer")]
    public class RegisterCustomerEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [StringLength(200)]
        public string CorpName { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [StringLength(200)]
        public string Connector { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [StringLength(200)]
        public string ConnectTel { get; set; }

        /// <summary>
        /// 公司规模
        /// </summary>
        [StringLength(200)]
        public string CorpScale { get; set; }

        /// <summary>
        /// 行业
        /// </summary>
        [StringLength(200)]
        public string Industry { get; set; }

        /// <summary>
        /// 差旅体量
        /// </summary>
        [StringLength(200)]
        public string TripScale { get; set; }

        /// <summary>
        /// 操作人员ID
        /// </summary>
        [StringLength(50)]
        public string OId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateDate { get; set; }
    }
}
