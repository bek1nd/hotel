using System.ComponentModel;

namespace Mzl.DomainModel.Customer.MatchCorpPolicyAndAduit
{
    public class CorpAduitChangeModel
    {
        public int AduitId { get; set; }
        public string AduitName { get; set; }

        [Description("审批规则描述")]
        public string AduitDescription { get; set; }
    }
}
