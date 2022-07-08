using System;
namespace Week3HwConverterApi
{
    public class Converter : IConverter
    {
        public double ConvertGallonsToLiter(int valueGallon)
        {
            return valueGallon * 3.785412;
        }

        public double ConvertLitersToGallon(int valueLiter)
        {
            return valueLiter * 0.2641722;
        }

        public double ConvertMilesToKm(int valueMiles)
        {
            return valueMiles * 1.069;
        }

        public double ConvertKmToMiles(int valueKm)
        {
            return valueKm * 0.621371;
        }

        public IEnumerable<ConversionModel> ConvertValues(ConversionModel conversionModel)
        {
            var resultToReturn = new List<ConversionModel>();
            resultToReturn.Add(conversionModel);
            var conversionResult = new ConversionModel();
            switch (conversionModel.ValueType)
            {
                case ValueType.Gallons:
                {
                        resultToReturn.Add(new ConversionModel
                        {
                            ValueType = ValueType.Liters,
                            Value = ConvertGallonsToLiter((int)conversionModel.Value)
                        });
                    break;
                }

                case ValueType.Liters:
                    {
                        resultToReturn.Add(new ConversionModel
                        {
                            ValueType = ValueType.Gallons,
                            Value = ConvertLitersToGallon((int)conversionModel.Value)
                        });
                        break;
                    }
                case ValueType.Kilometers:
                    {
                        resultToReturn.Add(new ConversionModel
                        {
                            ValueType = ValueType.Miles,
                            Value = ConvertKmToMiles((int)conversionModel.Value)
                        });
                        break;
                    }
                case ValueType.Miles:
                    {
                        resultToReturn.Add(new ConversionModel
                        {
                            ValueType = ValueType.Kilometers,
                            Value = ConvertMilesToKm((int)conversionModel.Value)
                        });
                        break;
                    }
            }
           
            return resultToReturn;
        }
    }
}

