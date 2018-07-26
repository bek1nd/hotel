using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mzl.EntityModel.Common
{
    /// <summary>
    /// 城市表
    /// </summary>
    [Table("Flt_City")]
    public partial class CityEntity
    {
        [Key]
        public int CityId { get; set; }

        public int Pid { get; set; }

        [Required]
        [StringLength(100)]
        public string CityName { get; set; }

        [StringLength(100)]
        public string CityEnName { get; set; }

        [Required]
        [StringLength(3)]
        public string CityCode { get; set; }

        public int? AreaId { get; set; }
        /// <summary>
        /// 国家Id
        /// </summary>
        public int? Pcid { get; set; }

        [StringLength(50)]
        public string PinYin { get; set; }

        [StringLength(50)]
        public string PinYinShort { get; set; }

        [StringLength(1)]
        public string IsInter { get; set; }
    }
}
