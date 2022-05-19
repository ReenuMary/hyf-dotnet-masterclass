using System;
namespace DotnetWeek2HwTest
{
    public class JupiterTime
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }

        public JupiterTime(int hours, int minutes)
        {
            if(hours > 0  && minutes > 0)
            {
                Minutes = minutes;
                Hours = hours;
                if (minutes > 60)
                {
                    hours += minutes / 60;
                    minutes = minutes % 60;
                }
                if (hours >= 10)
                {
                    hours = hours % 10;
                } 
            }
           else
            {
                throw new ArgumentException("Hours and minutes cannot be negative");
            }

           
        }

        public JupiterTime AddHours(int hours, out string day)
        {
            JupiterTime calculatedTime = this;
            calculatedTime.Hours += hours;
            day = "the same day";

        if (calculatedTime.Hours < 0)
            {
                day = $"{ (calculatedTime.Hours / -10) + 1 } day/s before";
                calculatedTime.Hours = 10 + calculatedTime.Hours % 10;
            }
            else if (calculatedTime.Hours >= 10)
            {
                day = $"{ calculatedTime.Hours / 10} day/s after";
                calculatedTime.Hours = calculatedTime.Hours % 10;
            }
           

            return calculatedTime;
        }

        public JupiterTime AddMinutes(int minutes, out string day)
        {
            JupiterTime calculatedTime = this;
            day = "the same day";
            calculatedTime.Minutes += minutes;

            if (calculatedTime.Minutes <= -60 || calculatedTime.Minutes >= 60)
            {
               calculatedTime.Hours = calculatedTime.AddHours(calculatedTime.Minutes / 60, out day).Hours;
               calculatedTime.Minutes = calculatedTime.Minutes % 60;
            }
            if (calculatedTime.Minutes < 0)
            {
                calculatedTime.Minutes = (60+ calculatedTime.Minutes );
                calculatedTime.AddHours(-1,out day);
            }

            return calculatedTime;
        }

        public override string ToString()
        {
            string minutes = Minutes < 10 ? $"0{Minutes}" : $"{Minutes}";
            return ($"0{Hours} : {minutes} ");
        }
    }
}
