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
    public class InventoryResponse
    {
        private Inventory[] inventoriesField;

        /// <summary>
        /// 房态库存
        /// </summary>
        public Inventory[] Inventories
        {
            get
            {
                return this.inventoriesField;
            }
            set
            {
                this.inventoriesField = value;
            }
        }
    }
}
