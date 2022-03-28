using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeLibraryNetStandard2
{
    public class HeartbeatEventArgs : EventArgs
    {
        public HeartbeatEventArgs(int heartbeatTick, DateTime startTime)
        {
            HeartBeatTick = heartbeatTick;
            StartLiving = startTime;
            AverageTickRate = (int)Math.Round((DateTime.Now - StartLiving).TotalMilliseconds / HeartBeatTick, 0);
        }
        public int HeartBeatTick { get; private set; }
        public DateTime StartLiving { get; private set; }

        public int AverageTickRate { get; private set; }
    }
}
