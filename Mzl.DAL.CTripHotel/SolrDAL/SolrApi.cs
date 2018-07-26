using CommonServiceLocator;
using Mzl.DAL.CTripHotel.Configuration;
using SolrNet;
using SolrNet.Commands.Parameters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DAL.CTripHotel.SolrDAL
{
    public class SolrApi
    {
        public static void Add<TDoc>(TDoc doc,string coreName)
        {
            var solr = SolrClientInit<TDoc>(coreName);
            solr.Add(doc);
            solr.Commit();
        }
        public static void Adds<TDoc>(List<TDoc> docs,string coreName)
        {
            var solr = SolrClientInit<TDoc>(coreName);
            foreach(var c in docs)
            {
                try
                {
                    solr.Add(c);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
            solr.Commit();
        }
        public static SolrQueryResults<Type> Gets<Type>(string queryStr,string coreName)
        {
            return SolrClientInit<Type>(coreName).Query(new SolrQuery(queryStr)); 
        }
        public static SolrQueryResults<TType> Query<TType>(string queryString,QueryOptions op,string coreName)
        {
            if (op == null)
            {
                return QueryOpNull<TType>(queryString, coreName);
            }
            var solr = SolrClientInit<TType>(coreName);
            return solr.Query(new SolrQuery(queryString),op);
        }

        public static SolrQueryResults<TType> QueryOpNull<TType>(string queryString, string coreName)
        {
            var solr = SolrClientInit<TType>(coreName);
            return solr.Query(new SolrQuery(queryString));
        }
        /// <summary>
        /// 初始化solr客户端
        /// </summary>
        /// <typeparam name="TDoc"></typeparam>
        /// <returns></returns>
        public static ISolrOperations<TDoc> SolrClientInit<TDoc>(string coreName)
        {
            Startup.Container.Clear();
            Startup.InitContainer();
            Startup.Init<TDoc>(ApiGatewayConfig.SolrURL+coreName);
            return ServiceLocator.Current.GetInstance<ISolrOperations<TDoc>>();
        }
    }
}
