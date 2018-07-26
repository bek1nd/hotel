using Mzl.Common.EnumHelper.ElongEnum;
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
    public class InstantOrderResponse
    {
        private EnumInstantStatus instantStatusField;

        /// <summary>
        /// 即时确认状态
        /// </summary>
        public EnumInstantStatus InstantStatus
        {
            get
            {
                return this.instantStatusField;
            }
            set
            {
                this.instantStatusField = value;
            }
        }
    }
}
