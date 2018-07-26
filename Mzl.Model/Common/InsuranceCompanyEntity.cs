using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Mzl.EntityModel.Common
{
    /// <summary>
    /// 保险项目信息
    /// </summary>
    [Table("Flt_InsuranceCompany")]
    public class InsuranceCompanyEntity
    {
        [Key]
        public int CompanyID { get; set; }

        [Required]
        [StringLength(200)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(200)]
        public string ProductName { get; set; }

        [StringLength(200)]
        public string InsuranceTypeName { get; set; }

        public decimal FacePrice { get; set; }

        public decimal SalePrice { get; set; }

        public decimal LowPrice { get; set; }

        public int MaxOrderCount { get; set; }

        [Required]
        [StringLength(500)]
        public string ApplicableRange { get; set; }

        public int InsurancePeriod { get; set; }

        [Required]
        [StringLength(8000)]
        public string InsuranceDesc { get; set; }

        [StringLength(50)]
        public string Insured { get; set; }

        [Required]
        [StringLength(1)]
        public string IsDel { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(30)]
        public string CraeteOid { get; set; }

        [StringLength(300)]
        public string TiaokuanZhu { get; set; }

        [StringLength(3000)]
        public string TiaokuanRemark { get; set; }

        [Required]
        [StringLength(1)]
        public string UpOnLine { get; set; }

        [StringLength(500)]
        public string CompanyWebAddress { get; set; }

        public int? FAID { get; set; }
    }
}
