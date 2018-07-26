using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Application.Train.Order.Analysis
{
    /// <summary>
    /// 出发到达站解析规则
    /// </summary>
    public class AnalysisStation : AnalysisBasic
    {
        public override void DoAnalysis(AnalysisContext context)
        {
            char[] analysisChar = context.GetAnalysisStr().ToCharArray();
            string[] stations = new string[] {"",""};
            int? spaceIndex = null;
            int? zhanIndex = null;
            int? spaceIndex2 = null;
            int? zhanIndex2 = null;
            for (int i = 0; i < analysisChar.Length; i++)
            {
                if (analysisChar[i].ToString() == "次" && !spaceIndex.HasValue)
                {
                    spaceIndex = i;
                }
                if (analysisChar[i].ToString() == "站" && !zhanIndex.HasValue)
                {
                    zhanIndex = i;
                }

                if (analysisChar[i].ToString() == "—" && spaceIndex.HasValue && zhanIndex.HasValue && !spaceIndex2.HasValue)
                {
                    spaceIndex2 = i;
                }
                if (analysisChar[i].ToString() == "站" && spaceIndex.HasValue && zhanIndex.HasValue&& spaceIndex2.HasValue)
                {
                    zhanIndex2 = i;
                }

                if (spaceIndex.HasValue&& zhanIndex.HasValue&& spaceIndex2.HasValue && zhanIndex2.HasValue)
                {
                    break;
                }
            }

            if (!spaceIndex.HasValue)
            {
                throw new Exception("未解析到出发车站");
            }
            if (!spaceIndex2.HasValue)
            {
                throw new Exception("未解析到出发车站");
            }
            if (!zhanIndex.HasValue)
            {
                throw new Exception("未解析到到达车站");
            }
            if (!zhanIndex2.HasValue)
            {
                throw new Exception("未解析到到达车站");
            }


            for (int i= spaceIndex.Value+1;i< zhanIndex.Value;i++)
            {
                stations[0] = stations[0] + analysisChar[i];
            }

            for (int i = spaceIndex2.Value + 1; i < zhanIndex2.Value; i++)
            {
                stations[1] = stations[1] + analysisChar[i];
            }


            if (stations[0] == null)
            {
                throw new Exception("未解析到出发车站");
            }
            if (stations[1] == null)
            {
                throw new Exception("未解析到到达车站");
            }
            context.GetDetail().StartName = stations[0].Trim();
            context.GetDetail().EndName = stations[1].Trim();
            context.SetDetail(context.GetDetail());
        }
    }
}
