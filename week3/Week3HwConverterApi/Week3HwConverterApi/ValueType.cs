using System;
using System.Text.Json.Serialization;

namespace Week3HwConverterApi
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum ValueType
	{
		Miles,
		Kilometers,
		Gallons,
		Liters
	}
}

