using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Train.Order;

namespace Mzl.Application.Train.Order.Analysis
{
    /// <summary>
    /// 乘车人解析股则
    /// </summary>
    public class AnalysisPassenger : AnalysisBasic
    {
        public override void DoAnalysis(AnalysisContext context)
        {
            string[] analysisStr = context.GetAnalysisStr().Split('\n');
            List<string> passengerLines = new List<string>();
            for (int i = 0; i < analysisStr.Length; i++)
            {
                string[] line = analysisStr[i].Trim().Split(' ');
                if (line[line.Length - 1] == "元")
                {
                    passengerLines.Add(analysisStr[i].Trim());
                }
            }
            if(passengerLines.Count==0)
                throw new Exception("未解析到乘车人信息");
            context.GetDetail().PassengerList=new List<TraPassengerModel>();
            //1 谢玉莲 二代身份证 431223199002284666 成人票 二等座 03 01A号 478.0 元
            //0    1          2                      3                             4          5     6     7       8       9
            for (int i = 0; i < passengerLines.Count; i++)
            {
                string[] line = passengerLines[i].Trim().Split(' ');
                if(line.Length!=10)
                    continue;
                TraPassengerModel p = new TraPassengerModel()
                {
                    Name = line[1],
                    AgeType = (line[4] == "成人票" ? AgeTypeEnum.C : AgeTypeEnum.E),
                    CardNo = line[3],
                    CardNoType = (line[2] == "二代身份证" ? CardTypeEnum.Certificate : CardTypeEnum.Passport),
                    PlaceGrade = line[5],
                    PlaceSeatNo =  line[7],
                    PlaceCar = line[6],
                    FacePrice = Convert.ToDecimal(line[8])
                };

                context.GetDetail().PassengerList.Add(p);
            }

            context.SetDetail(context.GetDetail());
        }
    }
}
