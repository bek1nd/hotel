using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.Ioc
{
    public class IocHelper
    {
        private readonly string _containerName;
        private static ConcurrentDictionary<string, IUnityContainer> _containerDictionary = new ConcurrentDictionary<string, IUnityContainer>();
        private IUnityContainer _container;
        public IocHelper(string name)
        {
            _containerName = name;
        }

        public IUnityContainer GetUnityContainer()
        {
            IUnityContainer container = GetCache(_containerName);
            if (container != null)
                return container;
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "App_Data\\Unity.Config.xml")
            };
            //找配置文件的路径
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
            if (section.Containers.ToList().Find(n => n.Name == _containerName) == null)//查找当前容器名称是否存在配置文件中
            {
                return null;
            }
            container = new UnityContainer();
            section.Configure(container, _containerName);
            SaveCache(_containerName, container);
            return container;
        }

        private void SaveCache(string key, IUnityContainer value)
        {
            if (!_containerDictionary.ContainsKey(key))
                _containerDictionary.TryAdd(key, value);
            else
            {
                _containerDictionary.TryRemove(key, out value);
                _containerDictionary.TryAdd(key, value);
            }
        }

        private IUnityContainer GetCache(string key)
        {
            if (_containerDictionary.ContainsKey(key))
                return _containerDictionary[key];
            return _container;
        }
    }
}
