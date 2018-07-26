using Mzl.Common.ConfigHelper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Mzl.Framework.UnitOfWork
{
    public class DbContextFactory
    {
        private static readonly string TypeDll = AppSettingsHelper.GetAppSettings(AppSettingsEnum.DbContext);
        private static readonly string DllName = TypeDll.Split(',')[1];
        private static readonly string TypeName = TypeDll.Split(',')[0];

        public static DbContext CreateDbContext()
        {
            DbContext dbContext = HttpContext.Current.Items[AppSettingsEnum.DbContext.ToString()] as DbContext;
            if (dbContext == null)
            {

                Assembly assembly = Assembly.Load(DllName);
                Type type = assembly.GetType(TypeName);
                object oDbContext = Activator.CreateInstance(type);
                dbContext = oDbContext as DbContext;

                HttpContext.Current.Items[AppSettingsEnum.DbContext.ToString()] = dbContext;
            }
            return dbContext;
        }
    }
}
