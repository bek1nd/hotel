using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mzl.Common.RegexHelper
{
    public class RegexHelper
    {
        /// <summary>
        /// 判断是否是日期
        /// </summary>
        /// <param name="strSource"></param>
        /// <returns></returns>
        public static bool IsDate(string strSource)
        {
            return Regex.IsMatch(strSource,
                @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$");
        }

        /// <summary>
        /// 判断是否是时间
        /// </summary>
        /// <param name="strSource"></param>
        /// <param name="isNeedThird"></param>
        /// <returns></returns>
        public static bool IsTime(string strSource,bool isNeedThird=false)
        {
            if (!isNeedThird)
                return Regex.IsMatch(strSource, @"^((20|21|22|23|[0-1]?\d):[0-5]?\d)$");
            return Regex.IsMatch(strSource, @"^((20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)$");
        }

        /// <summary>
        /// 手机号码验证
        /// </summary>
        /// <param name="strMobiel"></param>
        /// <returns></returns>
        public static bool IsMobile(string strMobiel) {
            return Regex.IsMatch(strMobiel, "^1([358][0-9]|4[579]|66|7[0135678]|9[89])[0-9]{8}$");
        }
    }
}
