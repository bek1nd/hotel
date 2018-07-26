using Mzl.IDAL.Train.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Model.Train.Server;
using IBatisNet.DataMapper;
using Mzl.Common.MyBatis;

namespace Mzl.DAL.Train.Server
{
    public class CallBackLogDAL : ICallBackLogDAL
    {
        public int Delete(Tra_CallBackLog_OriginalEntity t)
        {
            throw new NotImplementedException();
        }

        public Tra_CallBackLog_OriginalEntity Query()
        {
            return new Tra_CallBackLog_OriginalEntity();
        }

        public ICollection<Tra_CallBackLog_OriginalEntity> QueryList()
        {
            return new List<Tra_CallBackLog_OriginalEntity>();
        }

        public int Save(Tra_CallBackLog_OriginalEntity t)
        {
            string stmtName = "Tra_CallBackLog_Original.Update";
            return MyBatisProvider.GetInstanse().Update(stmtName, t);
        }

        public int Update(Tra_CallBackLog_OriginalEntity t)
        {
            return 0;
        }
    }
}
