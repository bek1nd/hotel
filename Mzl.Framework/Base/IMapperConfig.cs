using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Framework.Base
{
    /// <summary>
    /// Mapper映射接口
    /// </summary>
    public interface IMapperConfig
    {
        void InitializeConfig(IMapperConfigurationExpression cfg);
    }
}
