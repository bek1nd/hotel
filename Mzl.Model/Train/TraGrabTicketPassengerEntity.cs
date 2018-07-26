using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Train
{
    [Table("Tra_GrabTicketPassenger")]
    public class TraGrabTicketPassengerEntity
    {
        /// <summary>
        /// 抢票乘车人Id
        /// </summary>
        [Key]
        [Description("抢票乘车人Id")]
        public int GrabPassengerId { get; set; }
        /// <summary>
        /// 抢票Id
        /// </summary>
        [Description("抢票Id")]
        public int GrabId { get; set; }
        /// <summary>
        /// 乘客姓名
        /// </summary>
        [Description("乘客姓名")]
        [Required]
        public string PassengerName { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        [Description("证件号码")]
        [Required]
        public string CardNo { get; set; }
        /// <summary>
        /// 证件类型id
        /// </summary>
        [Description("证件类型id")]
        [Required]
        public int CardType { get; set; }
        /// <summary>
        /// 证件类型名称
        /// </summary>
        [Description("证件类型名称")]
        [Required]
        public string CardTypeName { get; set; }
        /// <summary>
        /// 票种 ID
        /// </summary>
        [Description("票种 ID")]
        [Required]
        public int TicketType { get; set; }
        /// <summary>
        /// 票种名称
        /// </summary>
        [Description("票种名称")]
        [Required]
        public string TicketTypeName { get; set; }
    }
}
