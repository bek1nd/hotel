using Mzl.Framework.Base;
using Mzl.IApplication.XingA;
using Mzl.IBLL.XingA;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.XingA;

namespace Mzl.Application.XingA
{
    internal class XingAGetDataApplication: BaseApplicationService, IXingAGetDataApplication
    {
        public IXingAGetDataBll _xingaBll;
        public XingAGetDataApplication(IXingAGetDataBll xingaBll):base()
        {
            _xingaBll = xingaBll;
        }

        public int AddData(XingAModel model)
        {
            //将视图模型转成业务模型              
            return  _xingaBll.AddData(model);
             
        }
    }
}
