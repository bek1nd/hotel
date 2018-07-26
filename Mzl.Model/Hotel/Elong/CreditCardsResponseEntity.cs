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
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true, ElementName = "CreditCards")]
    public class CreditCardsResponseEntity 
    {
        [System.Xml.Serialization.XmlArrayItemAttribute("CreditCard")]
        public List<CreditCard> CreditCardList { get; set; }
    }
}
