using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Common.Insurance
{
    public class InsuranceCompanyModel
    {
        public int CompanyID { get; set; }

        public string CompanyName { get; set; }

        public string ProductName { get; set; }

        public string InsuranceTypeName { get; set; }

        public decimal FacePrice { get; set; }

        public decimal SalePrice { get; set; }

        public decimal LowPrice { get; set; }

        public int MaxOrderCount { get; set; }

        public string ApplicableRange { get; set; }

        public int InsurancePeriod { get; set; }

        public string InsuranceDesc { get; set; }

        public string Insured { get; set; }

        public string IsDel { get; set; }

        public DateTime? CreateTime { get; set; }

        public string CraeteOid { get; set; }

        public string TiaokuanZhu { get; set; }

        public string TiaokuanRemark { get; set; }
        public string UpOnLine { get; set; }

        public string CompanyWebAddress { get; set; }

        public int? FAID { get; set; }
    }
}
