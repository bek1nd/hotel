using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper
{
    public class WeekHelper
    {
        public static string GetWeek(DayOfWeek week)
        {
            string[] weekdays = { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            string weekDesc = weekdays[Convert.ToInt32(week)];
            return weekDesc;
        }
    }
}
