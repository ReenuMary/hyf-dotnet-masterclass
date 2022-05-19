using System;

namespace DotnetWeek2HwTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //  var time = new JupiterTime(14,88);
            //time.Hours = 8;
            //time.Minutes = 4;
            //PrintTime(time);
            string day = string.Empty;
            var time = new JupiterTime(2, 20);
             var timeAfterAddingHours = time.AddHours(-26,out  day);
             PrintTime(timeAfterAddingHours);
             PrintMessage(day);

         /*   var timeAfterAddingMinutes = time.AddMinutes(-145,out day);
            PrintTime(timeAfterAddingMinutes);
            PrintMessage(day);*/
        }

        static void PrintTime(JupiterTime time)
        {
            if(time.Minutes<10)
            {
                Console.WriteLine($"Jupiter time is {time.Hours}:0{time.Minutes}");
            }
            else
            {
                Console.WriteLine($"Jupiter time is {time.Hours}:{time.Minutes}");
            }
        }

        static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
