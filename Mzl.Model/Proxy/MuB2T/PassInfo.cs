using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 旅客信息
    /// </summary>
    public class PassInfo
    {
        /// <summary>
        /// 旅客姓名
        /// </summary>
        public string passName { get; set; }
        /// <summary>
        /// 旅客类型
        /// </summary>
        public string passType { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string idType { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string idNo { get; set; }
        /// <summary>
        /// 旅客性别
        /// </summary>
        public string passGender { get; set; }
        /// <summary>
        /// 旅客生日
        /// </summary>
        public string passBirthday { get; set; }
        /// <summary>
        /// 旅客国籍
        /// </summary>
        public string passNationCd { get; set; }
        /// <summary>
        /// 护照发证国
        /// </summary>
        public string passportIssueCd { get; set; }
        /// <summary>
        /// 护照有效期
        /// </summary>
        public string passportValidDt { get; set; }
        /// <summary>
        /// 国内证件号
        /// </summary>
        public string domesticIdNo { get; set; }
        /// <summary>
        /// 居住地街道
        /// </summary>
        public string docaStreetR { get; set; }
        /// <summary>
        /// 居住地城市
        /// </summary>
        public string docaCityR { get; set; }
        /// <summary>
        /// 居住地州/省
        /// </summary>
        public string docaStateR { get; set; }
        /// <summary>
        /// 居住地邮编
        /// </summary>
        public string docaPostR { get; set; }
        /// <summary>
        /// 目的地街道
        /// </summary>
        public string docaStreetD { get; set; }
        /// <summary>
        /// 目的地城市
        /// </summary>
        public string docaCityD { get; set; }
        /// <summary>
        /// 目的地州/省
        /// </summary>
        public string docaStateD { get; set; }
        /// <summary>
        /// 目的地邮编
        /// </summary>
        public string docaPostD { get; set; }
        /// <summary>
        /// 旅客联系方式
        /// </summary>
        public string contactPhone { get; set; }
    }
}
