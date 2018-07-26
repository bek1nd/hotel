using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mzl.EntityModel.Customer.AppClient
{
    [Table("P_CustomerAppClientId")]
    public class CustomerAppClientIdEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Cid { get; set; }
        [Required]
        [MaxLength(500)]
        public string ClientId { get; set; }
        [Required]
        [MaxLength(10)]
        public string ClientType { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
