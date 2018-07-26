using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.Common.Exceptions;
using Mzl.DomainModel.Flight;
using Mzl.EntityModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight;

namespace Mzl.BLL.Flight
{
    public class CheckPassengerIsInWhiteListBll : BaseBll, ICheckPassengerIsInWhiteListBll
    {
        public string Result { get; private set; }

        public bool CheckPassenger(List<FltPassengerModel> passengerList, bool isCheckName)
        {
            if (isCheckName)
                return CheckPassengerByName(passengerList);

            return CheckPassengerByCardNo(passengerList);
        }

        public bool CheckPassengerName(string name)
        {
            var select = from white in
               base.Context.Set<FltWhiteListPassengerEntity>()
                         select white;
            select = select.Where(n => name.ToUpper() == n.PassengerName.ToUpper());

            if (select.Any())
                return true;
            return false;
        }

        public bool CheckPassengerCardNo(string cardNo)
        {
            var select = from white in
               base.Context.Set<FltWhiteListPassengerEntity>()
                         select white;
            select = select.Where(n => cardNo.ToUpper() == n.CardNo.ToUpper());

            if (select.Any())
                return true;
            return false;
        }

        /// <summary>
        /// 通过证件号检查
        /// </summary>
        /// <param name="passengerList"></param>
        private bool CheckPassengerByCardNo(List<FltPassengerModel> passengerList)
        {
            return Check(passengerList, false);
        }

        /// <summary>
        /// 通过人名检查
        /// </summary>
        /// <param name="passengerList"></param>
        private bool CheckPassengerByName(List<FltPassengerModel> passengerList)
        {
            return Check(passengerList, true);
        }


        private bool Check(List<FltPassengerModel> passengerList, bool isCheckName)
        {
            List<string> cardNoList = new List<string>();
            List<string> nameList = new List<string>();
            foreach (var fltPassengerModel in passengerList)
            {
                if (isCheckName)
                    nameList.Add(fltPassengerModel.Name);
                else
                    cardNoList.Add(fltPassengerModel.CardNo);
            }

            var select = from white in
                base.Context.Set<FltWhiteListPassengerEntity>()
                select white;

            if (cardNoList.Count > 0)
                select = select.Where(n => cardNoList.Contains(n.CardNo));
            if (nameList.Count > 0)
                select = select.Where(n => nameList.Contains(n.PassengerName));

            List<FltWhiteListPassengerEntity> list = select.OrderBy(n=>n.AgreementNo).Distinct().ToList(); //匹配到的白名单信息

            if (list.Count == 0)
                return false;



            #region 如果在名单内，获取对应的协议号信息
            foreach (var fltPassengerModel in passengerList)
            {
                string numberNo = "";
                string name = "";
                if (cardNoList.Count > 0)
                {
                    numberNo = list.Find(n => n.CardNo == fltPassengerModel.CardNo)?.AgreementNo;
                    name = list.Find(n => n.CardNo == fltPassengerModel.CardNo)?.PassengerName;
                }

                if (nameList.Count > 0)
                {
                    numberNo = list.Find(n => n.PassengerName == fltPassengerModel.Name)?.AgreementNo;
                    name = list.Find(n => n.PassengerName == fltPassengerModel.Name)?.PassengerName;
                }

                Result += "," + string.Format("{0}({1})", name, numberNo);
            }

            if (!string.IsNullOrEmpty(Result))
                Result = "请开协议：" + Result.Substring(1); 
            #endregion

            return true;
        }
    }
}
