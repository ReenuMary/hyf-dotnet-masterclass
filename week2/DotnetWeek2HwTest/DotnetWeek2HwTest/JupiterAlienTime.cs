using System;
namespace DotnetWeek2HwTest
{
    public class JupiterAlienTime : AlienTime<JupiterAlienTime>
    {
        public JupiterAlienTime(int hours, int minutes , int dayHours = 10) : base(hours, minutes, dayHours)
        {
        }

        public override JupiterAlienTime AddHours(int hours, out string day)
        {
            JupiterAlienTime calculatedTime = this;
            calculatedTime.Hours += hours;
            day = "the same day";

            if (calculatedTime.Hours < 0)
            {
                day = $"{ (calculatedTime.Hours / (-1 * this.hoursInADay)) + 1 } day/s before";
                calculatedTime.Hours = this.hoursInADay + calculatedTime.Hours % this.hoursInADay;
            }
            else if (calculatedTime.Hours >= this.hoursInADay)
            {
                day = $"{ calculatedTime.Hours / this.hoursInADay} day/s after";
                calculatedTime.Hours = calculatedTime.Hours % this.hoursInADay;
            }


            return calculatedTime;
        }
    }
}

