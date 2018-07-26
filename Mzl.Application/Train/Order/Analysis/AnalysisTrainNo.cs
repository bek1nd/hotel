using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Application.Train.Order.Analysis
{
    /// <summary>
    /// 车次解析规则
    /// </summary>
    public class AnalysisTrainNo : AnalysisBasic
    {
        public override void DoAnalysis(AnalysisContext context)
        {
            char[] analysisChar = context.GetAnalysisStr().ToCharArray();

            int? index = null;
            for (int i = 0; i < analysisChar.Length; i++)
            {
                if (analysisChar[i].ToString() == "次")
                {
                    index = i;
                    break;
                }
            }
            if(!index.HasValue)
                throw new Exception("未解析到车次");

            StringBuilder sb = new StringBuilder();
            for (int i=0;i< index.Value;i++)
            {
                sb.Append(analysisChar[i].ToString());
            }

            string[] line = sb.ToString().Trim().Split(' ');//根据空格分割字符串
            context.GetDetail().TrainNo = line[line.Length-1].Trim();
            context.SetDetail(context.GetDetail());
        }
    }
}
