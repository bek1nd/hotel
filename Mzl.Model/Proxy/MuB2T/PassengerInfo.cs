using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 旅客信息
    /// </summary>
    public class PassengerInfo
    {
        /// <summary>
        /// 旅客序号
        /// </summary>
        public int? PassengerSq { get; set; }
        /// <summary>
        /// 旅客姓名
        /// </summary>
        public string PassengerName { get; set; }
        /// <summary>
        /// 旅客类型
        /// </summary>
        public string PassengerType { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string PassengerIdType { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string PassengerIdNo { get; set; }
        /// <summary>
        /// 旅客性别
        /// </summary>
        public string PassengerGender { get; set; }
        /// <summary>
        /// 旅客生日
        /// </summary>
        public string PassengerBirthday { get; set; }
        /// <summary>
        /// 旅客国籍
        /// </summary>
        public string PassengerNationCd { get; set; }
        /// <summary>
        /// 护照发证国
        /// </summary>
        public string PassportIssueCd { get; set; }
        /// <summary>
        /// 护照有效期
        /// </summary>
        public string PassportValidDt { get; set; }
        /// <summary>
        /// 国内证件号
        /// </summary>
        public string DomesticIdNo { get; set; }
        /// <summary>
        /// 居住地街道
        /// </summary>
        public string DocaStreetR { get; set; }
        /// <summary>
        /// 居住地城市
        /// </summary>
        public string DocaCityR { get; set; }
        /// <summary>
        /// 居住地州/省
        /// </summary>
        public string DocaStateR { get; set; }
        /// <summary>
        /// 居住地邮编
        /// </summary>
        public string DocaPostR { get; set; }
        /// <summary>
        /// 目的地街道
        /// </summary>
        public string DocaStreetD { get; set; }
        /// <summary>
        /// 目的地城市
        /// </summary>
        public string DocaCityD { get; set; }
        /// <summary>
        /// 目的地州/省
        /// </summary>
        public string DocaStateD { get; set; }
        /// <summary>
        /// 目的地邮编
        /// </summary>
        public string DocaPostD { get; set; }
        /// <summary>
        /// 旅客联系方式
        /// </summary>
        public string ContactPhone { get; set; }
        /// <summary>
        /// 票号
        /// </summary>
        public string TktNo { get; set; }
    }
}
