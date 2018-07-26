using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Hotel.Elong
{
    public class OrderCancelResponse
    {
        private bool successsField;

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Successs
        {
            get
            {
                return this.successsField;
            }
            set
            {
                this.successsField = value;
            }
        }
    }
}
