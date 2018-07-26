using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Hotel.Elong
{
    public class OrderRoom
    {
        private Customer[] customersField;
        private string roomNoField;

        /// <summary>
        /// 客人信息
        /// </summary>
        public Customer[] Customers
        {
            get
            {
                return this.customersField;
            }
            set
            {
                this.customersField = value;
            }
        }
        /// <summary>
        /// 入住房间号
        /// </summary>
        public string RoomNo
        {
            get
            {
                return this.roomNoField;
            }
            set
            {
                this.roomNoField = value;
            }
        }
    }
}
