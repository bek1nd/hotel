using IBatisNet.Common.Utilities;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Mzl.Common.MyBatis
{
    public class MyBatisProvider
    {
        private static ISqlMapper _sqlMapper;
        private static object sysncObj = new object();
        public static ISqlMapper GetInstanse()
        {
            if (_sqlMapper == null)
            {
                lock (sysncObj)
                {
                    if (_sqlMapper == null)
                    {
                        //_sqlMapper = IBatisNet.DataMapper.Mapper.Instance();//---第一种

                        _sqlMapper = new DomSqlMapBuilder().Configure(); //---第二种

                        //XmlDocument sqlMapConfig = Resources.GetEmbeddedResourceAsXmlDocument("Mzl.Common.MyBatis.SqlMap.config, Mzl.Common.MyBatis");
                        //
                        //_sqlMapper = new DomSqlMapBuilder().Configure(sqlMapConfig);  //---第三种

                    }
                }
            }
            return _sqlMapper;
        }
    }
}
