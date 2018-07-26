using Mzl.BLL.Train.Server.BLL;
using Mzl.Common.JsonHelper;
using Mzl.Common.MD5Helper;
using Mzl.Common.PostHelper;
using Mzl.DomainModel.Train.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mzl.Mojor.WebApi.newTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            QueryTrainServerBLL qsl = new QueryTrainServerBLL();
            SearchTrainModel stm = new SearchTrainModel();
            stm.PartnerID = "miaozhilv";
            stm.Method = "train_query";
            stm.Reqtime = DateTime.Now.ToString("yyyyMMddHHmmss");
            stm.Sign = MD5Helper.GetSign(stm.PartnerID, stm.Method, stm.Reqtime);
            stm.Train_Date = "2017-07-08";
            stm.From_Station = "bjb";
            stm.To_Station = "njn";
            stm.Purpose_Codes = "ADULT";
            stm.NeedDistance = "0";
            string jsonstr =  JsonHelper.SerializeObject(stm).ToLower();
            qsl.Data = jsonstr;
           ;
            MessageBox.Show(qsl.DoPostRequest());
        }
    }
}
