using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mzl.EntityModel.Common
{
    /// <summary>
    /// 机场表
    /// </summary>
    [Table("Flt_AirPort")]
    public partial class AirPortEntity
    {
        [Key]
        [StringLength(3)]
        public string AirportCode { get; set; }

        [Required]
        [StringLength(100)]
        public string AirportName { get; set; }

        [StringLength(100)]
        public string AirportEnName { get; set; }

        public int? AreaId { get; set; }

        public int? CityId { get; set; }

        [Required]
        [StringLength(3)]
        public string CityCode { get; set; }

        [StringLength(1)]
        public string IsInter { get; set; }

        [Required]
        [StringLength(100)]
        public string AirportLongName { get; set; }
    }
}
