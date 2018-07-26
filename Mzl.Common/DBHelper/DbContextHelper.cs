using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.DBHelper
{
    public static class DbContextHelper
    {
        public static int Update<T>(this DbContext db,T t, string[] properties = null) where T : class
        {
            DbEntityEntry<T> entry = db.Entry(t);
            db.Set<T>().Attach(t);
            if (properties == null)
            {
                entry.State = EntityState.Modified;
            }
            else
            {
                foreach (var item in properties)
                {
                    entry.Property(item).IsModified = true;
                }
            }
            int i = db.SaveChanges();
            if (i > 0)
                return 0;
            return -1;
        }
        private static string AirName(string AirNum)
        {
            string returnval = "";
            switch (AirNum)
            {
                case "781":
                    returnval = "东航/上航(MU/FM)";
                    break;
                case "784":
                    returnval = "南方航空(CZ)";
                    break;
                case "018":
                    returnval = "吉祥航空(HO)";
                    break;
                case "999":
                    returnval = "中国国际航空(CA)";
                    break;
                case "731":
                    returnval = "厦门航空(MF)";
                    break;
                case "876":
                    returnval = "四川航空(3U)";
                    break;
                case "836":
                    returnval = "河北航空(NS)";
                    break;
                case "479":
                    returnval = "深圳航空(ZH)";
                    break;
                default:
                    returnval = "Unknown";
                    break;
            }
            return returnval;
        }
    }
}
