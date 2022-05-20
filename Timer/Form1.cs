using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinTimer
{
    public partial class WinTimer : Form
    {
        public WinTimer()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Tick += new EventHandler(TimeTick);
            timer.Interval = 800;
            
        }
        Timer timer = null;
        private int StartCount = 0;
        private string StringTimer(int time)
        {
            int hours = (time - (time % (60 * 60)) / (60 * 60));
            int minutes = (time - time % 60) / 60 - hours * 60;
            int seconds = time - hours * 60 * 60 - minutes * 60;
            return String.Format("{0:00}:{1:00}:{2:00}", hours,minutes,seconds);
        }
        void TimeTick(object sender,EventArgs e)
        {
            if(StartCount != 0)
            {
                label1.Text = StringTimer(StartCount);
                StartCount--;
            }
            else
            {
                (sender as Timer).Stop();
                (sender as Timer).Dispose();
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            StartCount =  (int)numericUpDown1.Value +  (int)numericUpDown2.Value + (int)numericUpDown3.Value;
            timer.Start();
            
        }
    }
}
