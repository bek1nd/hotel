using Mzl.DomainModel.XingA;
using Mzl.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IApplication.XingA
{
    public interface IXingAGetDataApplication: IBaseApplication
    {
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="model">数据对象</param>
        /// <returns>添加结果</returns>
        int AddData(XingAModel model);
    }
}
