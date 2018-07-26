using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mzl.EntityModel.Common
{
    /// <summary>
    /// 国家表
    /// </summary>
    [Table("P_Country")]
    public partial class CountryEntity
    {
        [Key]
        public int Pcid { get; set; }

        public int ContinentId { get; set; }

        [Required]
        [StringLength(50)]
        public string CName { get; set; }

        [Required]
        [StringLength(50)]
        public string CEName { get; set; }

        [Required]
        [StringLength(3)]
        public string CountryCode { get; set; }

        [Required]
        [StringLength(2)]
        public string CountryShortCode { get; set; }

        [StringLength(50)]
        public string Capital { get; set; }

        [StringLength(200)]
        public string CountryFullName { get; set; }
    }
}
