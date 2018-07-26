using Mzl.Common.RegexHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Application.Train.Order.Analysis
{
    /// <summary>
    /// 出发到达时间解析规则
    /// </summary>
    public class AnalysisTime : AnalysisBasic
    {
        public override void DoAnalysis(AnalysisContext context)
        {
            char[] analysisChar = context.GetAnalysisStr().ToCharArray();
            string[] tackOffTime = new string[2];
            for (int i = 0; i < analysisChar.Length; i++)
            {
                string need = "";
                int begin = i;
                int end = i + 5;
                if (end > analysisChar.Length)
                {
                    end = analysisChar.Length;
                }
                for (int k = begin; k < end; k++)
                {
                    need = need + analysisChar[k].ToString();
                }

                if (RegexHelper.IsTime(need))
                {
                    if (tackOffTime[0] == null)
                    {
                        tackOffTime[0] = need;
                    }
                    else if (tackOffTime[0] != null && tackOffTime[1] == null)
                    {
                        tackOffTime[1] = need;
                    }
                }
            }
            if (tackOffTime[0] == null)
            {
                throw new Exception("未解析到出发时间");
            }
            if (tackOffTime[1] == null)
            {
                throw new Exception("未解析到到达时间");
            }
            DateTime startTime = context.GetDetail().StartTime;
            context.GetDetail().StartTime = Convert.ToDateTime(startTime.ToString("yyyy-MM-dd") + " " + tackOffTime[0]);
            context.GetDetail().EndTime = Convert.ToDateTime(startTime.ToString("yyyy-MM-dd") + " " + tackOffTime[1]);
            context.SetDetail(context.GetDetail());
        }
    }
}
