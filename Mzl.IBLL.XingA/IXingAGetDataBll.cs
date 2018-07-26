using Mzl.DomainModel.XingA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.XingA
{
    public interface IXingAGetDataBll
    {
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="AddXingAModel">数据对象</param>
        /// <returns>添加结果</returns>
        int AddData(XingAModel AddXingAModel);
    }
}
