using Mzl.Framework.Base;
using Mzl.IBLL.Customer.ContactInfo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.EntityModel.Customer.Contact;
using Mzl.IDAL.Customer.ContactInfo;
using AutoMapper;

namespace Mzl.BLL.Customer.ContactInfo
{
    public class GetContactBll: BaseBll, IGetContactBll
    {
        private readonly IContactDal _contactDal;
        public GetContactBll(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public List<ContactInfoModel> GetContactByContactId(List<int> contactIdList)
        {
          
            List<ContactInfoEntity> contactInfoEntities =
                _contactDal.Query<ContactInfoEntity>(n => contactIdList.Contains(n.Contactid)).ToList();

            return Mapper.Map<List<ContactInfoEntity>, List<ContactInfoModel>>(contactInfoEntities);
        }
        /// <summary>
        /// 获取差旅客户对应信息
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public ContactInfoModel GetCorpContactByCid(int cid)
        {
            ContactInfoEntity contactInfoEntity =
                _contactDal.Query<ContactInfoEntity>(n => n.PCid == cid && n.IsPassenger == "T").FirstOrDefault();

            return Mapper.Map<ContactInfoEntity, ContactInfoModel>(contactInfoEntity);
        }
        /// <summary>
        /// 获取差旅客户对应信息
        /// </summary>
        /// <param name="cidList"></param>
        /// <returns></returns>
        public List<ContactInfoModel> GetCorpContactByCid(List<int> cidList)
        {
            List<ContactInfoEntity> contactInfoEntities =
                _contactDal.Query<ContactInfoEntity>(
                    n => n.PCid.HasValue && cidList.Contains(n.PCid.Value) && n.IsPassenger == "T").ToList();


            return Mapper.Map<List<ContactInfoEntity>, List<ContactInfoModel>>(contactInfoEntities);
        }

        public List<ContactInfoModel> GetContactByCid(int cid)
        {
            var query =
               _contactDal.Query<ContactInfoEntity>(
                   n => n.Cid == cid && !n.PCid.HasValue && n.IsPassenger != "T" && n.IsDel == "F");

            List<ContactInfoEntity> contactInfoEntities = SearchContact(query, null).ToList();

            return Mapper.Map<List<ContactInfoEntity>, List<ContactInfoModel>>(contactInfoEntities);
        }

        public List<ContactInfoModel> GetContactByCid(int cid, string args)
        {
            var query=
                _contactDal.Query<ContactInfoEntity>(
                    n => n.Cid == cid && !n.PCid.HasValue && n.IsPassenger != "T" && n.IsDel == "F");

            List<ContactInfoEntity> contactInfoEntities = SearchContact(query, args).ToList();

            return ConvertToModel(contactInfoEntities);
        }

        public List<ContactInfoModel> GetContactByCid(List<int> cidList)
        {
            var query =
                _contactDal.Query<ContactInfoEntity>(
                    n => cidList.Contains(n.Cid) && !n.PCid.HasValue && n.IsPassenger != "T" && n.IsDel == "F");

            List<ContactInfoEntity> contactInfoEntities = SearchContact(query, null).ToList();

            return Mapper.Map<List<ContactInfoEntity>, List<ContactInfoModel>>(contactInfoEntities);
        }

        public List<ContactInfoModel> GetContactByCid(List<int> cidList, string args)
        {
            var query =
                _contactDal.Query<ContactInfoEntity>(
                    n => cidList.Contains(n.Cid) && !n.PCid.HasValue && n.IsDel == "F");

            List<ContactInfoEntity> contactInfoEntities = SearchContact(query, args).ToList();

            return ConvertToModel(contactInfoEntities);
        }


        private IQueryable<ContactInfoEntity> SearchContact(IQueryable<ContactInfoEntity> contactInfoEntitieses,string searchArgs)
        {
            if (!string.IsNullOrEmpty(searchArgs))
            {
                contactInfoEntitieses =
                    contactInfoEntitieses.Where(n => (!string.IsNullOrEmpty(n.Ename) && n.Ename.Contains(searchArgs))
                                                     ||
                                                     (!string.IsNullOrEmpty(n.Cname) && n.Cname.Contains(searchArgs))
                                                     || (!string.IsNullOrEmpty(n.Mobile) && n.Mobile == searchArgs));
            }
            return contactInfoEntitieses;
        }

        private List<ContactInfoModel> ConvertToModel(List<ContactInfoEntity> contactInfoEntities)
        {
            if (contactInfoEntities == null || contactInfoEntities.Count == 0)
                return null;

            List<ContactInfoModel> models =
                Mapper.Map<List<ContactInfoEntity>, List<ContactInfoModel>>(contactInfoEntities);

            //去除重复人名，这里未对英文人名做处理，如果有英文人名问题，请自行修改 :)
            List<string> contactNameList = contactInfoEntities.Select(n => n.Cname).Distinct().ToList();
            List<ContactInfoModel> resultList = new List<ContactInfoModel>();
            foreach (var name in contactNameList)
            {
                var m=models.Find(n => n.CName == name);
                if(m!=null)
                    resultList.Add(m);
            }

            return resultList;
        }
    }
}
