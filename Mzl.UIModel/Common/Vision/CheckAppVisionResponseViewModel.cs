using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Common.Vision
{
    public class CheckAppVisionResponseViewModel
    {
        public int Code { get; set; }
        public string AndroidUrl { get; set; }
        public string IosUrl { get; set; }
        public string Message { get; set; }
    }
}
