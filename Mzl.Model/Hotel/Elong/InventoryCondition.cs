using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Hotel.Elong
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public class InventoryCondition
    {
        private string hotelIdsField;
        private string hotelCodesField;
        private string roomTypeIdField;
        private System.DateTime startDateField;
        private System.DateTime endDateField;
        private bool isNeedInstantConfirmField;

        /// <summary>
        /// 酒店Id
        /// 最多10个,逗号分隔
        /// </summary>
        public string HotelIds
        {
            get
            {
                return this.hotelIdsField;
            }
            set
            {
                this.hotelIdsField = value;
            }
        }

        /// <summary>
        /// 供应商房型编号
        /// </summary>
        public string RoomTypeId
        {
            get
            {
                return this.roomTypeIdField;
            }
            set
            {
                this.roomTypeIdField = value;
            }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public System.DateTime StartDate
        {
            get
            {
                return this.startDateField;
            }
            set
            {
                this.startDateField = value;
            }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public System.DateTime EndDate
        {
            get
            {
                return this.endDateField;
            }
            set
            {
                this.endDateField = value;
            }
        }

        /// <summary>
        /// 是否返回即时确认数据
        /// 建议不使用，返回速度会变慢
        /// </summary>
        public bool IsNeedInstantConfirm
        {
            get
            {
                return this.isNeedInstantConfirmField;
            }
            set
            {
                this.isNeedInstantConfirmField = value;
            }
        }
    }
}
