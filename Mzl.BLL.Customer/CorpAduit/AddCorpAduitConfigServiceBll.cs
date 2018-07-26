using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.EntityModel.Customer.Corporation.CorpAudit;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.IDAL.Customer.Corporation;

namespace Mzl.BLL.Customer.CorpAduit
{
    public class AddCorpAduitConfigServiceBll: BaseServiceBll, IAddCorpAduitConfigServiceBll
    {
        private readonly ICorpAduitConfigDal _corpAduitConfigDal;
        private readonly ICorpAduitConfigDetailDal _corpAduitConfigDetailDal;
        public AddCorpAduitConfigServiceBll(ICorpAduitConfigDal corpAduitConfigDal, ICorpAduitConfigDetailDal corpAduitConfigDetailDal)
        {
            _corpAduitConfigDal = corpAduitConfigDal;
            _corpAduitConfigDetailDal = corpAduitConfigDetailDal;
        }
        public bool AddCorpAduitConfig(CorpAduitConfigModel model)
        {
            if (model.DetailList != null && model.DetailList.Count > 0)
            {
                List<int> orderTypeList = new List<int>
                {
                    (int) OrderSourceTypeEnum.Flt,
                    (int) OrderSourceTypeEnum.FltModApply,
                    (int) OrderSourceTypeEnum.FltRetApply,
                    (int) OrderSourceTypeEnum.Tra
                };
                foreach (var i in orderTypeList)
                {
                    var tList=model.DetailList.FindAll(n => n.OrderType == i);
                    if (tList != null && tList.Count > 0)
                    {
                        Check(tList);
                    }
                }
            }


            CorpAduitConfigEntity corpAduitConfigEntity = Mapper.Map<CorpAduitConfigModel, CorpAduitConfigEntity>(model);
            corpAduitConfigEntity.CreateTime=DateTime.Now;
            List<CorpAduitConfigDetailEntity> corpAduitConfigDetailEntities = Mapper
                .Map<List<CorpAduitConfigDetailModel>, List<CorpAduitConfigDetailEntity>>(
                    model.DetailList);

            corpAduitConfigEntity = _corpAduitConfigDal.Insert(corpAduitConfigEntity);

            if (corpAduitConfigDetailEntities != null && corpAduitConfigDetailEntities.Count > 0)
            {
                foreach (var cporCorpAduitConfigDetailEntity in corpAduitConfigDetailEntities)
                {
                    if ((cporCorpAduitConfigDetailEntity.PolicyTypeAduit ?? 0) == 0)
                    {
                        throw new Exception("请设置差旅政策审批使用范围");
                    }

                    cporCorpAduitConfigDetailEntity.ConfigId = corpAduitConfigEntity.ConfigId;
                    _corpAduitConfigDetailDal.Insert(cporCorpAduitConfigDetailEntity);
                }
            }
           

            return true;
        }

        private void Check(List<CorpAduitConfigDetailModel> detailListAll)
        {
            List<int> flowList = new List<int>();
            detailListAll.ForEach(n => { flowList.Add(n.AduitLevel); });
            foreach (int flow in flowList)
            {
                List<CorpAduitConfigDetailModel> detailList = detailListAll.FindAll(n => n.AduitLevel == flow);
                int count = detailList.Count;
                List<int> cidList = detailList.Select(n => n.AduitCid).Distinct().ToList();
                if (count != cidList.Count)
                {
                    throw new Exception("同一级别不能设置相同审批人");
                }
            }
        }
    }
}
