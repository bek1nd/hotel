using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Hotel.CTrip.Hotel
{
    public class MealInfo
    {
        /// <summary>
        /// 早餐类型
        /// 0：未知；1：不包含儿童早餐；2：包含儿童早餐
        /// </summary>
        public int BreakfastType { get; set; }
    }
}
