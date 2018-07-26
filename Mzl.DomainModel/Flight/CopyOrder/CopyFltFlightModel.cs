using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight.CopyOrder
{
    public class CopyFltFlightModel
    {
        public int Sequence { get; set; }
        public decimal SalePrice { get; set; }

        public decimal TaxFee { get; set; }

        public decimal OilFee { get; set; }

        public decimal Rate { get; set; }
    }
}
