using System;
namespace Week3HwConverterApi
{
    public class Converter : IConverter
    {
        public double ConvertGallonsToLitre(int valueGallon)
        {
            return valueGallon * 3.785412;
        }
    }
}

