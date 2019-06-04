using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiService.Services
{
    public class BackgroundTimer
    {
        private Timer timer;
        private int getDataDelay = 9000;
        public int GetDataDelay
        {
            get
            {
                return getDataDelay / 1000;
            }
            set
            {
                getDataDelay = value * 1000;
                timer?.Change(0, value * 1000);
            }
        }

        public void setCallback(TimerCallback callback)
        {
            timer = new Timer(callback, null, 0, getDataDelay);
        }


        public void stopTimer()
        {
            timer?.Change(Timeout.Infinite, 0);
        }

        public void Dispose()
        {
            timer.Dispose();
        }
    }
}
