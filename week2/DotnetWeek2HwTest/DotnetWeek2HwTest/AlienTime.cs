using System;
namespace DotnetWeek2HwTest
{
    public abstract class AlienTime<T>
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }

        protected int hoursInADay { get; }
        private const int minutesInAnHour = 60;

        public AlienTime(int hours,int minutes, int dayHours)
        {
            if (hours > 0 && minutes > 0)
            {
                Minutes = minutes;
                Hours = hours;
                hoursInADay = dayHours;
                if (Minutes > minutesInAnHour)
                {
                    Hours += Minutes / minutesInAnHour;
                    Minutes = Minutes % minutesInAnHour;
                }
                if (Hours >= hoursInADay)
                {
                    Hours = Hours % hoursInADay;
                }
            }
            else
            {
                throw new ArgumentException("Hours and minutes cannot be negative");
            }
        }

        public override string ToString()
        {

            string minutes = Minutes < 10 ? $"0{Minutes}" : $"{Minutes}";
            return ($"{Hours} : {minutes} ");
        }

        public abstract T AddHours(int hours, out string day);
    }
}

