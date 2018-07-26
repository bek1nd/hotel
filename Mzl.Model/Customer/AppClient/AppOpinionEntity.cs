using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Customer.AppClient
{
    /// <summary>
    /// App意见表
    /// </summary>
    [Table("P_AppOpinion")]
    public class AppOpinionEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AppOpinion { get; set; }
        public int AppType { get; set; }
        public DateTime CreateTime { get; set; }
        public int CreateCid { get; set; }
    }
}
