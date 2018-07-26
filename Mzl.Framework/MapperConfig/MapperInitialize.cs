using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using AutoMapper;
using Mzl.Framework.Base;

namespace Mzl.Framework.MapperConfig
{
    public class MapperInitialize
    {
        /// <summary>
        /// 初始化Mapper
        /// </summary>
        public void InitializeMapper()
        {
            List<IMapperConfig> mapperConfigs = GetMapperConfig();
            Mapper.Initialize(cfg =>
            {
                mapperConfigs.ForEach(x =>
                {
                    x.InitializeConfig(cfg);
                });
            });
        }


        /// <summary>
        /// 通过反射获取Mapper配置信息
        /// </summary>
        private List<IMapperConfig> GetMapperConfig()
        {
            List<IMapperConfig> mapperConfigs = new List<IMapperConfig>();
            string codeBase = HttpRuntime.BinDirectory; //得到Bin的路劲
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            string bin = Path.GetDirectoryName(path);
            if (bin == null)
                throw new Exception("查无dll文件");
            string[] assemblies = Directory.GetFiles(bin, "*.dll");

            Assembly asm;
            foreach (string file in assemblies)
            {
                try
                {
                    if (File.Exists(file))
                    {
                        asm = Assembly.LoadFrom(file); //Assembly：是一个程序集
                        //寻找实现定义接口的类 
                        var query = from t in asm.GetTypes()
                            where t.IsClass && t.GetInterface(typeof (IMapperConfig).FullName) != null
                            select t;

                        // 添加泛型集合到启动任务列表
                        foreach (Type type in query)
                        {
                            mapperConfigs.Add((IMapperConfig) Activator.CreateInstance(type));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return mapperConfigs;

        }
    }
}
