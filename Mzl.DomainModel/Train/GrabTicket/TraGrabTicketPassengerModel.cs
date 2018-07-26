using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;

namespace Mzl.DomainModel.Train.GrabTicket
{
    public class TraGrabTicketPassengerModel
    {
        public int GrabPassengerId { get; set; }
        /// <summary>
        /// 抢票Id
        /// </summary>
        public int GrabId { get; set; }
        /// <summary>
        /// 乘客姓名
        /// </summary>
        public string PassengerName { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string CardNo { get; set; }
        /// <summary>
        /// 证件类型id
        /// </summary>
        public CardTypeEnum CardType { get; set; }
        /// <summary>
        /// 空铁无忧证件类型
        /// </summary>
        public string KongTieCardType
        {
            get
            {
                switch (CardType)
                {
                    case CardTypeEnum.Certificate:
                        return "1";
                    case CardTypeEnum.Passport:
                        return "B";
                    case CardTypeEnum.HongKongAndMacaoPass:
                        return "C";
                    case CardTypeEnum.MTP:
                        return "G";
                    case CardTypeEnum.TaiwanEntryPermit:
                        return "G";
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// 证件类型名称
        /// </summary>
        public string CardTypeName => CardType.ToDescription();
        /// <summary>
        /// 票种 ID
        /// </summary>
        public AgeTypeEnum TicketType { get; set; }
        /// <summary>
        /// 空铁无忧票种类型
        /// </summary>
        public string KongTieTicketType
        {
            get
            {
                switch (TicketType)
                {
                    case AgeTypeEnum.C:
                        return "1";
                    case AgeTypeEnum.E:
                        return "2";
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// 票种名称
        /// </summary>
        public string TicketTypeName => TicketType.ToDescription();

        public string Mobile { get; set; }

        public int ContactId { get; set; }
    }
}
