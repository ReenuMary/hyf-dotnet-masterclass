using System;
using System.Text.Json.Serialization;

namespace Week3HwConverterApi
{
	public class ConversionModel
	{
       
        public ValueType ValueType { get; set; }
        public Double Value { get; set; }
    }
}

