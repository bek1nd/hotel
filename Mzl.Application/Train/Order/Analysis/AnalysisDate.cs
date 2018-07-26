using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.RegexHelper;

namespace Mzl.Application.Train.Order.Analysis
{
    /// <summary>
    /// 出发到达日期解析规则
    /// </summary>
    public class AnalysisDate : AnalysisBasic
    {
        public override void DoAnalysis(AnalysisContext context)
        {
            char[] analysisChar = context.GetAnalysisStr().ToCharArray();
            string tackOffDate = "";
            for (int i = 0; i < analysisChar.Length; i++)
            {
                string need = "";
                int begin = i;
                int end = i + 10;
                if (end > analysisChar.Length)
                {
                    end = analysisChar.Length;
                }
                for (int k = begin; k < end; k++)
                {
                    need = need + analysisChar[k];
                }

                if (RegexHelper.IsDate(need))
                {
                    if (string.IsNullOrEmpty(tackOffDate))
                    {
                        tackOffDate = need;
                        context.GetDetail().StartTime = Convert.ToDateTime(tackOffDate);
                        context.SetDetail(context.GetDetail());
                        return;
                    }
                }
            }
            throw new Exception("未解析到出发日期");
        }


    }
}
