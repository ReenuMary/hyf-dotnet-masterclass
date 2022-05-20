using System;
using DotnetWeek2HwTest;
using Xunit;

namespace JupiterTimeTest
{
    public class JupiterAlienTimeTest
    {
        [Theory]
        [InlineData(5, 20, 5, 20)]
        [InlineData(10, 20, 0, 20)]
        [InlineData(10, 120, 2, 0)]
        [InlineData(10, 190, 3, 10)]
        public void JupiterTimeTestForSettingTime(int hours, int minutes, int expectedHour, int expectedMinutes)
        {
            JupiterAlienTime testCaseJupiterAlienTime = new JupiterAlienTime(hours, minutes);
            Assert.Equal(testCaseJupiterAlienTime.Hours, expectedHour);
            Assert.Equal(testCaseJupiterAlienTime.Minutes, expectedMinutes);
        }
        [Theory]
        [InlineData(2, 20, 6, 8, 20, "the same day")]
        [InlineData(2, 20, -6, 6, 20, "1 day/s before")]
        [InlineData(2, 20, 12, 4, 20, "1 day/s after")]
        [InlineData(2, 20, -26, 6, 20, "3 day/s before")]
        [InlineData(2, 20, 26, 8, 20, "2 day/s after")]
        public void AddHoursAlienJupiterTimeTest(int hours, int minutes, int hoursToAdd, int expectedHour, int expectedMinute, string outputMessage)
        {
            var currentTime = new JupiterAlienTime(hours, minutes);
            string day = string.Empty;
            JupiterAlienTime calculatedTime = currentTime.AddHours(hoursToAdd, out day);

            Assert.Equal(calculatedTime.Hours, expectedHour);
            Assert.Equal(calculatedTime.Minutes, expectedMinute);
            Assert.Equal(day, outputMessage);
        }
    }
   
}

