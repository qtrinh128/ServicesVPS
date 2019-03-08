using ServiceCheckOrderTool.Model;
using System;
using System.IO;
using System.ServiceProcess;
using System.Timers;

namespace ServiceCheckOrderTool
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        private Timer timer = null;

        protected override void OnStart(string[] args)
        {
            timer = new Timer
            {
                Interval = 3600000
            };
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DateTime time = DateTime.Now;
            decimal hour = time.Hour;
            int check = Convert.ToInt32(hour);
            if (check == 0)
            {
                string path = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "config\\path.txt");
                ModelService.OpenTool(path);
            }
            //string path = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "config\\path.txt");
            //ModelService.OpenTool(path);
            //ModelService.WriteLogError(hour.ToString());
        }

        protected override void OnStop()
        {
            ModelService.WriteLogError("WindowsService has been stop");
        }
    }
}
