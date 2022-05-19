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
            if (TimeToSendSignals.Count == 0)
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

        public void Check(JupiterTime jupiterTime)
        {
            List<JupiterTime> missedSignalTimes = new List<JupiterTime>();
            foreach (var signalTime in TimeToSendSignals)
            {
                if(signalTime.Hours <  jupiterTime.Hours)
                {
                    missedSignalTimes.Add(signalTime);
                }
                else if(signalTime.Hours == jupiterTime.Hours)
                {
                    if (signalTime.Minutes <= jupiterTime.Minutes)
                    {
                        missedSignalTimes.Add(signalTime);
                    }
                }
            }
            //Print the missed times
            PrintMissedTimes(missedSignalTimes);

        }

        private void PrintMissedTimes(List<JupiterTime> missedSignalTimes)
        {
            if(missedSignalTimes.Count==0)
            {
                Console.WriteLine("No signals needed to be sent yet");
            }
            else
            {
               foreach(var missedTime in missedSignalTimes)
                {
                    Console.WriteLine(missedTime.ToString());
                }
            }
        }
    }
}

