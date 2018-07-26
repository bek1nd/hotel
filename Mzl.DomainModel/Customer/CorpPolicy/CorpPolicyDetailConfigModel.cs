using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.Corp;
using Mzl.DomainModel.Customer.CorpDepartment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Customer.CorpPolicy
{
    public class CorpPolicyDetailConfigModel
    {
        /// <summary>
        /// 政策Id
        /// </summary>
        public int PolicyId { get; set; }
        /// <summary>
        /// 客户Id
        /// </summary>
        public int? Cid { get; set; }

        #region 国内
        /// <summary>
        ///  国内机票低价航班为出发时间前后PolicyVal分钟内最低航班
        /// </summary>
        public string NPolicyValL { get; set; }
        /// <summary>
        ///  国内机票提前预定 提前PolicyVal天以上预定航班
        /// </summary>
        public string NPolicyValT { get; set; }
        /// <summary>
        /// 国内机票折扣限制
        /// </summary>
        public string NPolicyValR { get; set; }
        /// <summary>
        /// 国内机票购买保险
        /// </summary>
        public string NPolicyValI { get; set; }
        /// <summary>
        /// 国内机票仓等限制
        /// </summary>
        public string NPolicyValY { get; set; }
        /// <summary>
        /// 国内机票改签是否允许换仓
        /// </summary>
        public string NPolicyValA { get; set; }
        /// <summary>
        /// 国内机票改签差价金额数值
        /// </summary>
        public string NPolicyValB { get; set; }
        /// <summary>
        /// 国内机票改签差价金额百分比
        /// </summary>
        public string NPolicyValC { get; set; }
        /// <summary>
        /// 国内机票退票金额数值
        /// </summary>
        public string NPolicyValE { get; set; }
        /// <summary>
        /// 国内机票退票金额百分比
        /// </summary>
        public string NPolicyValF { get; set; }
        #endregion

        #region 国际
        /// <summary>
        ///  国际机票低价航班为出发时间前后PolicyVal分钟内最低航班
        /// </summary>
        public string IPolicyValL { get; set; }
        /// <summary>
        /// 国际机票提前预定 提前PolicyVal天以上预定航班
        /// </summary>
        public string IPolicyValT { get; set; }
        /// <summary>
        /// 国际机票折扣限制
        /// </summary>
        public string IPolicyValR { get; set; }
        /// <summary>
        /// 国际机票购买保险
        /// </summary>
        public string IPolicyValI { get; set; }
        #endregion

        #region 火车
        /// <summary>
        /// 火车票快车席别最高限制
        /// </summary>
        public string TPolicyValQ { get; set; }
        /// <summary>
        /// 火车票普车/其他最高限制
        /// </summary>
        public string TPolicyValM { get; set; }
        /// <summary>
        /// 火车票最高卧铺限制
        /// </summary>
        public string TPolicyValS { get; set; } 
        #endregion
       

        /// <summary>
        /// 客户信息
        /// </summary>
        public CustomerInfoModel CustomerInfoModel { get; set; }
        /// <summary>
        /// 公司信息
        /// </summary>
        public CorporationModel CorpModel { get; set; }
        /// <summary>
        /// 公司部门信息
        /// </summary>
        public CorpDepartmentModel CorpDepartmentModel { get; set; }
        /// <summary>
        /// 差旅违规原因
        /// </summary>
        public List<string > PolicyReason { get; set; }
        public List<ChoiceReasonModel> PolicyReasonList { get; set; }
    }
}
