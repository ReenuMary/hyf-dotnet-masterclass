using System;
using DotnetWeek2HwTest;
using Xunit;

namespace JupiterTimeTest
{
	public class JupiterTimeTest
	{
		[Theory]
		[InlineData(5,20,5,20 )]
		[InlineData(10, 20, 0, 20)]
		[InlineData(10, 120, 2, 0)]
		[InlineData(10, 190, 3, 10)]
		public void JupiterTimeTestForSettingTime(int hours, int minutes ,int  expectedHour, int expectedMinutes)
		{
			JupiterTime testCaseJupiterTime = new JupiterTime(hours, minutes);
			Assert.Equal(testCaseJupiterTime.Hours, expectedHour);
			Assert.Equal(testCaseJupiterTime.Minutes, expectedMinutes);
		}

		[Theory]
		[InlineData(0, -2)]
		[InlineData(-5, 2)]
		[InlineData(-8, -2)]
		public void JupiterTimeTestForSettingTime_InvalidInput(int hours, int minutes)
		{			
			Assert.Throws<ArgumentException>(() => new JupiterTime(hours, minutes));
		}

		[Theory]
		[InlineData(2, 20,6,8,20, "the same day")]
		[InlineData(2, 20, -6, 6, 20, "1 day/s before")]
		[InlineData(2, 20, 12, 4, 20, "1 day/s after")]
		[InlineData(2, 20, -26, 6, 20, "3 day/s before")]
		[InlineData(2, 20, 26, 8, 20, "2 day/s after")]
		public void AddHoursTest(int hours,int minutes,int hoursToAdd,int expectedHour, int expectedMinute, string outputMessage)
		{
			JupiterTime currentTime = new JupiterTime(hours, minutes);
			string day = string.Empty;

			JupiterTime calculatedTime = currentTime.AddHours(hoursToAdd, out day);

			Assert.Equal(calculatedTime.Hours, expectedHour);
			Assert.Equal(calculatedTime.Minutes, expectedMinute);
			Assert.Equal(day, outputMessage);
		}

		[Theory]
		[InlineData(2, 20, 6, 2, 26, "the same day")]
		[InlineData(2, 20, 40, 3, 0, "the same day")]
		[InlineData(2, 20, 80, 3, 40, "the same day")]
		[InlineData(9, 20, 40, 0, 0, "1 day/s after")]
		[InlineData(9, 20, 120, 1, 20, "1 day/s after")]
		[InlineData(1, 20, -120, 9, 20, "1 day/s before")]
		public void AddMinutesTest(int hours, int minutes, int minutesToAdd, int expectedHour, int expectedMinute, string outputMessage)
        {
			JupiterTime currentTime = new JupiterTime(hours, minutes);
			string day = string.Empty;

			JupiterTime calculatedTime = currentTime.AddMinutes(minutesToAdd, out day);

			Assert.Equal(calculatedTime.Hours, expectedHour);
			Assert.Equal(calculatedTime.Minutes, expectedMinute);
			Assert.Equal(day, outputMessage);
		}

	}
}

