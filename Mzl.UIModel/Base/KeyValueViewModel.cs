using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Base
{
    public class KeyValueViewModel<T,S>
    {
        /// <summary>
        /// Key
        /// </summary>
        [Description("Key")]
        public T Key { get; set; }
        /// <summary>
        /// Value
        /// </summary>
        [Description("Value")]
        public S Value { get; set; }
    }
}
