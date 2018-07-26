using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Mzl.Common.PostHelper;

namespace Mzl.Mojory.Job.Train
{
    public partial class MakeUpService : ServiceBase
    {
        private Timer timer = new Timer();
        public MakeUpService()
        {
            InitializeComponent();
            this.timer.Elapsed += new ElapsedEventHandler(Timer_Tick);
            timer.Interval = 60000;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                this.timer.Enabled = false;
                string url = ConfigurationSettings.AppSettings["WakeUpUrl"];
                string ok = PostHelper.PostUrl(url + "/MojoryApi/TrainCallBack/Index", "11111", Encoding.UTF8);
            }
            catch
            {
            }
            finally
            {
                this.timer.Enabled = true;
            }
        }

        protected override void OnStart(string[] args)
        {
            this.timer.Enabled = true;
            this.timer.Start();
        }

        protected override void OnStop()
        {
            this.timer.Enabled = false;
            this.timer.Stop();
        }
    }
}
