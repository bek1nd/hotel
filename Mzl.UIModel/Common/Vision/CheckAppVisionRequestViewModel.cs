using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Common.Vision
{
    public class CheckAppVisionRequestViewModel : RequestBaseViewModel
    {
        [Required]
        public string Vision { get; set; }
    }
}
