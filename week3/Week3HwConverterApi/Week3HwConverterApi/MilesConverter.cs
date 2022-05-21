using System;
namespace Week3HwConverterApi
{
    public class MilesConverter : IMilesConverter
    {
        public IDistance ConvertMilesToKm(int miles)
        {
            IDistance distance = new Distance();
            distance.Miles = miles;
            distance.Kilometers = miles * 1.069;

            return distance;

        }


    }
}

