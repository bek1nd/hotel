using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 航班信息列表
    /// </summary>
    //[Serializable]
    public class FltItem
    {
        /// <summary>
        /// 航班号
        /// </summary>
        //[XmlElement]
        public string FLT_NO { get; set; }
        /// <summary>
        /// 机型
        /// </summary>
        //[XmlElement]
        public string FLT_TP { get; set; }
        /// <summary>
        /// 出发时间
        /// </summary>
        //[XmlElement]
        public string DEP_TM { get; set; }
        /// <summary>
        /// 实际承运人
        /// </summary>
        //[XmlElement]
        public string CARRIER { get; set; }
        /// <summary>
        /// 舱等代号组
        /// </summary>
        //[XmlElement]
        public string CLAS_TPS { get; set; }
        /// <summary>
        /// 价格信息列表（在返回时使用）
        /// </summary>
        //[XmlArrayItem]
        public List<ClasFare> clasFare { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[XmlElement]
        public string YSEAT_RATE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[XmlElement]
        public string f_SEAT_RATE { get; set; }
        public string F_SEAT_RATE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[XmlElement]
        public string J_SEAT_RATE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[XmlElement]
        public int? f_WEEKENDCODE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[XmlElement]
        public int? y_WEEKENDCODE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[XmlElement]
        //blic ClasFare sg_fcc { get; set; }
        public List<ClasFare> getClasFare { get; set; }
        public string Y_SEAT_RATE { get; set; }

        #region 2017-09-01新增
        public string y_SEAT_RATE { get; set; }        
        public string BOOKING_RATE { get; set; }
        public string ARR_TM { get; set; }
        public string j_SEAT_RATE { get; set; }

        //public string getCLAS_TPS { get; set; }
        //public string setCLAS_TPS { get; set; }
        //public string getFLT_NO { get; set; }
        //public string setFLT_NO { get; set; }
        //public string getY_SEAT_RATE { get; set; }
        //public string setY_SEAT_RATE { get; set; }
        //public string getF_SEAT_RATE { get; set; }
        //public string setF_SEAT_RATE { get; set; }
        //public string getJ_SEAT_RATE { get; set; }
        //public string setJ_SEAT_RATE { get; set; }
        //public float? getF_WEEKENDCODE { get; set; }
        //public string setF_WEEKENDCODE { get; set; }
        //public float? getY_WEEKENDCODE { get; set; }
        //public string setY_WEEKENDCODE { get; set; }
        //public string getFLT_TP { get; set; }
        //public string setFLT_TP { get; set; }
        //public string getDEP_TM { get; set; }
        //public string setDEP_TM { get; set; }
        //public string getCARRIER { get; set; }
        //public string setCARRIER { get; set; }        
        //public string setClasFare { get; set; }
        //public string getBOOKING_RATE { get; set; }
        //public string setBOOKING_RATE { get; set; }
        //public string getARR_TM { get; set; }
        //public string setARR_TM { get; set; }
        //public string getSerialversionuid { get; set; }
        #endregion
    }


}
