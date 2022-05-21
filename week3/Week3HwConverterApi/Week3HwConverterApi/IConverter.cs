namespace Week3HwConverterApi
{
    public interface IConverter
    {
        double ConvertGallonsToLiter(int valueGallon);
        IEnumerable<ConversionModel> ConvertValues(ConversionModel conversionModel);
    }
}