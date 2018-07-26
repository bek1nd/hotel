using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.EntityModel.Customer.Corporation.CorpAudit;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.IDAL.Customer.Corporation;
using Mzl.IDAL.Customer.Customer;

namespace Mzl.BLL.Customer.CorpAduit
{
    public class GetCorpAduitConfigServiceBll : BaseServiceBll, IGetCorpAduitConfigServiceBll
    {
        private readonly ICorpAduitConfigDal _corpAduitConfigDal;
        private readonly ICorpAduitConfigDetailDal _corpAduitConfigDetailDal;
        private readonly ICustomerDal _customerDal;

        public GetCorpAduitConfigServiceBll(ICorpAduitConfigDal corpAduitConfigDal, ICorpAduitConfigDetailDal corpAduitConfigDetailDal, ICustomerDal customerDal)
        {
            _corpAduitConfigDal = corpAduitConfigDal;
            _corpAduitConfigDetailDal = corpAduitConfigDetailDal;
            _customerDal = customerDal;
        }

        public List<CorpAduitConfigModel> GetCorpAduitConfigListByCorpId(string corpId)
        {
            List<CorpAduitConfigEntity> corpAduitConfigEntities =
                _corpAduitConfigDal.Query<CorpAduitConfigEntity>(n => n.CorpId == corpId && n.IsDel == 0, true).ToList();
            List<int> configList = new List<int>();
            corpAduitConfigEntities.ForEach(n=> configList.Add(n.ConfigId));

            List<CorpAduitConfigDetailEntity> corpAduitConfigDetailEntities =
                _corpAduitConfigDetailDal.Query<CorpAduitConfigDetailEntity>(n => configList.Contains(n.ConfigId), true).OrderBy(n=>n.AduitLevel)
                    .ToList();

            List<int> cidList = new List<int>();
            corpAduitConfigDetailEntities.ForEach(n =>
            {
                cidList.Add(n.AduitCid);
            });

            List<CustomerInfoEntity> customerInfoEntities =
                _customerDal.Query<CustomerInfoEntity>(n => cidList.Contains(n.Cid), true).ToList();


            List<CorpAduitConfigModel> corpAduitConfigModels =
                Mapper.Map<List<CorpAduitConfigEntity>, List<CorpAduitConfigModel>>(corpAduitConfigEntities);
            List< CorpAduitConfigDetailModel > corpAduitConfigDetailModels=
                   Mapper.Map<List<CorpAduitConfigDetailEntity>, List<CorpAduitConfigDetailModel>>(corpAduitConfigDetailEntities);
            foreach (var corpAduitConfigModel in corpAduitConfigModels)
            {
                corpAduitConfigModel.DetailList =
                    corpAduitConfigDetailModels.FindAll(n => n.ConfigId == corpAduitConfigModel.ConfigId);
                foreach (var corpAduitConfigDetailModel in corpAduitConfigModel.DetailList)
                {
                    corpAduitConfigDetailModel.AduitName =
                        customerInfoEntities.Find(n => n.Cid == corpAduitConfigDetailModel.AduitCid)?.RealName;
                }
            }

            return corpAduitConfigModels;
        }

        public CorpAduitConfigModel GetCorpAduitConfigById(int configId)
        {
            CorpAduitConfigEntity corpAduitConfigEntity = _corpAduitConfigDal.Find<CorpAduitConfigEntity>(configId);
            List<CorpAduitConfigDetailEntity> corpAduitConfigDetailEntities =
                _corpAduitConfigDetailDal.Query<CorpAduitConfigDetailEntity>(
                    n => n.ConfigId == corpAduitConfigEntity.ConfigId, true).OrderBy(n=>n.AduitLevel)
                    .ToList();

            List<int> cidList = new List<int>();
            corpAduitConfigDetailEntities.ForEach(n =>
            {
                cidList.Add(n.AduitCid);
            });

            List<CustomerInfoEntity> customerInfoEntities =
                _customerDal.Query<CustomerInfoEntity>(n => cidList.Contains(n.Cid), true).ToList();

            CorpAduitConfigModel corpAduitConfigModel =
                Mapper.Map<CorpAduitConfigEntity, CorpAduitConfigModel>(corpAduitConfigEntity);
            corpAduitConfigModel.DetailList =
                Mapper.Map<List<CorpAduitConfigDetailEntity>, List<CorpAduitConfigDetailModel>>(
                    corpAduitConfigDetailEntities);

            foreach (var corpAduitConfigDetailModel in corpAduitConfigModel.DetailList)
            {
                var customer = customerInfoEntities.Find(n => n.Cid == corpAduitConfigDetailModel.AduitCid);
                corpAduitConfigDetailModel.AduitName = customer?.RealName;
                corpAduitConfigDetailModel.IsCheckPerson = (customer?.IsCheckPerson == "T");
            }

            return corpAduitConfigModel;
        }
    }
}
