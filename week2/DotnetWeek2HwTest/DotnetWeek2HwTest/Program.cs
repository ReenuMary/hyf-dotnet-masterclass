using System;

namespace DotnetWeek2HwTest
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var time = new JupiterTime(14, 88);
            time.Hours = 8;
            time.Minutes = 4;
            PrintTime(time);
            string day;
            var time = new JupiterTime(2, 20);
            var timeAfterAddingHours = time.AddHours(-26,out  day);
            PrintTime(timeAfterAddingHours);
            PrintMessage(day);

            var timeAfterAddingMinutes = time.AddMinutes(-145,out day);
            PrintTime(timeAfterAddingMinutes);
            PrintMessage(day);

            var signaler = new Signaler();
            signaler.Inform();
            signaler.AddTime(new JupiterTime(1, 20));
            signaler.AddTime(new JupiterTime(2, 20));
            signaler.AddTime(new JupiterTime(3, 2));
            signaler.Inform();
            signaler.Check(new JupiterTime(1, 19));*/


            //test JupiteralienTime Printing
            var alienTime = new JupiterAlienTime(4, 50);
            Console.WriteLine(alienTime.ToString());
        }

        static void PrintTime(JupiterTime time)
        {
            /* if(time.Minutes<10)
             {
                 Console.WriteLine($"Jupiter time is {time.Hours}:0{time.Minutes}");
             }
             else
             {
                 Console.WriteLine($"Jupiter time is {time.Hours}:{time.Minutes}");
             }*/
            Console.WriteLine(time.ToString());


        }

        static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
