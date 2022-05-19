using System;
using System.Collections.Generic;

namespace DotnetWeek2HwTest
{
	public class Signaler
	{
        public List<JupiterTime> TimeToSendSignals { get; set; }

        public Signaler()
        {
            TimeToSendSignals = new List<JupiterTime>();
        }

        public void AddTime(JupiterTime jupiterTime)
        {
            TimeToSendSignals.Add(jupiterTime);
        }

        public void Inform()
        {
            if(TimeToSendSignals.Count==0)
            {
                Console.WriteLine("No Timers added yet");
            }
            else
            {
                foreach (var time in TimeToSendSignals)
                {
                    Console.WriteLine(time.ToString());
                }
            }
            
        }
    }
}

