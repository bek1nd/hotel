using Mzl.UIModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class QueryFltRetModApplyRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 申请Id
        /// </summary>
        [Required]
        public int? Rmid { get; set; }
    }
}
