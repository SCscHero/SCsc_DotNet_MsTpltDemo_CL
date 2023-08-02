using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Test4AplcCmptMidw.TestAplc
{
	/// <summary>
	/// https://learn.microsoft.com/zh-cn/dotnet/standard/serialization/system-text-json/how-to?pivots=dotnet-8-0
	/// </summary>
	internal partial class SystemMethodTest
	{

		private class Forecast
		{
			public DateTime Date;
			public int TemperatureC;
			public string? Summary;
		}

		private class Forecast2
		{
			[JsonInclude]
			public DateTime Date;
			[JsonInclude]
			public int TemperatureC;
			[JsonInclude]
			public string? Summary;
		}
		[Test]
		public void JsonSerializer_反序列化为指定字段()
		{
			var json =
	@"{""Date"":""2020-09-06T11:31:01.923395"",""TemperatureC"":-1,""Summary"":""Cold""} ";
			Console.WriteLine($"Input JSON: {json}");

			var options = new JsonSerializerOptions
			{
				IncludeFields = true,
			};
			var forecast = JsonSerializer.Deserialize<Forecast>(json, options)!;

			Console.WriteLine($"forecast.Date: {forecast.Date}");
			Console.WriteLine($"forecast.TemperatureC: {forecast.TemperatureC}");
			Console.WriteLine($"forecast.Summary: {forecast.Summary}");

			var roundTrippedJson =
				JsonSerializer.Serialize<Forecast>(forecast, options);

			Console.WriteLine($"Output JSON: {roundTrippedJson}");

			var forecast2 = JsonSerializer.Deserialize<Forecast2>(json)!;

			Console.WriteLine($"forecast2.Date: {forecast2.Date}");
			Console.WriteLine($"forecast2.TemperatureC: {forecast2.TemperatureC}");
			Console.WriteLine($"forecast2.Summary: {forecast2.Summary}");

			roundTrippedJson = JsonSerializer.Serialize<Forecast2>(forecast2);

			Console.WriteLine($"Output JSON: {roundTrippedJson}");
		}

			[Test]
		public void JsonSerializer_序列化为格式化的Json()
		{
			var weatherForecast = new WeatherForecast
			{
				Date = DateTime.Parse("2019-08-01"),
				TemperatureCelsius = 25,
				Summary = "Hot"
			};

			var options = new JsonSerializerOptions { WriteIndented = true };
			string jsonString = JsonSerializer.Serialize(weatherForecast, options);

			Console.WriteLine(jsonString);
		}


			[Test]
		public void JsonSerializer_从UTF8反序列化()
		{

			var weatherForecast = new WeatherForecast2
			{
				Date = DateTime.Parse("2019-08-01"),
				TemperatureCelsius = 25,
				Summary = "Hot",
				SummaryField = "Hot",
				DatesAvailable = new List<DateTimeOffset>()
					{ DateTime.Parse("2019-08-01"), DateTime.Parse("2019-08-02") },
				TemperatureRanges = new Dictionary<string, HighLowTemps>
				{
					["Cold"] = new HighLowTemps { High = 20, Low = -10 },
					["Hot"] = new HighLowTemps { High = 60, Low = 20 }
				},
				SummaryWords = new[] { "Cool", "Windy", "Humid" }
			};
			//若要序列化为 UTF-8 字节数组，请调用 JsonSerializer.SerializeToUtf8Bytes 方法：
			byte[] jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(weatherForecast);


			var readOnlySpan = new ReadOnlySpan<byte>(jsonUtf8Bytes);
			WeatherForecast deserializedWeatherForecast =
				JsonSerializer.Deserialize<WeatherForecast>(readOnlySpan)!;

			var utf8Reader = new Utf8JsonReader(jsonUtf8Bytes);
			WeatherForecast deserializedWeatherForecast1 =
				JsonSerializer.Deserialize<WeatherForecast>(ref utf8Reader)!;
		}



		[Test]
		public async Task JsonSerializer_异步从文件反序列化()
		{
			string fileName = "WeatherForecast.json";
			using FileStream openStream = File.OpenRead(fileName);
			WeatherForecast? weatherForecast =
				await JsonSerializer.DeserializeAsync<WeatherForecast>(openStream);

			Console.WriteLine($"Date: {weatherForecast?.Date}");
			Console.WriteLine($"TemperatureCelsius: {weatherForecast?.TemperatureCelsius}");
			Console.WriteLine($"Summary: {weatherForecast?.Summary}");
		}


		[Test]
		public void JsonSerializer_从文件反序列化()
		{
			string fileName = "WeatherForecast.json";
			string jsonString = File.ReadAllText(fileName);
			WeatherForecast weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(jsonString)!;

			Console.WriteLine($"Date: {weatherForecast.Date}");
			Console.WriteLine($"TemperatureCelsius: {weatherForecast.TemperatureCelsius}");
			Console.WriteLine($"Summary: {weatherForecast.Summary}");
		}

		[Test]
		public void JsonSerializer_反序列化()
		{
			string jsonString =
@"{
  ""Date"": ""2019-08-01T00:00:00-07:00"",
  ""TemperatureCelsius"": 25,
  ""Summary"": ""Hot"",
  ""DatesAvailable"": [
    ""2019-08-01T00:00:00-07:00"",
    ""2019-08-02T00:00:00-07:00""
  ],
  ""TemperatureRanges"": {
                ""Cold"": {
                    ""High"": 20,
      ""Low"": -10
                },
    ""Hot"": {
                    ""High"": 60,
      ""Low"": 20
    }
            },
  ""SummaryWords"": [
    ""Cool"",
    ""Windy"",
    ""Humid""
  ]
}
";
			WeatherForecast2? weatherForecast =
				JsonSerializer.Deserialize<WeatherForecast2>(jsonString);
			Console.WriteLine($"Date: {weatherForecast?.Date}");
			Console.WriteLine($"TemperatureCelsius: {weatherForecast?.TemperatureCelsius}");
			Console.WriteLine($"Summary: {weatherForecast?.Summary}");
		}


		[Test]
		public void JsonSerializer_序列化为UTF8Test()
		{
			//序列化为 UTF-8 字节数组比使用基于字符串的方法大约快 5-10%。 出现这种差别的原因是字节（作为 UTF-8）不需要转换为字符串 (UTF-16)。
			var weatherForecast = new WeatherForecast2
			{
				Date = DateTime.Parse("2019-08-01"),
				TemperatureCelsius = 25,
				Summary = "Hot",
				SummaryField = "Hot",
				DatesAvailable = new List<DateTimeOffset>()
					{ DateTime.Parse("2019-08-01"), DateTime.Parse("2019-08-02") },
				TemperatureRanges = new Dictionary<string, HighLowTemps>
				{
					["Cold"] = new HighLowTemps { High = 20, Low = -10 },
					["Hot"] = new HighLowTemps { High = 60, Low = 20 }
				},
				SummaryWords = new[] { "Cool", "Windy", "Humid" }
			};
			//若要序列化为 UTF-8 字节数组，请调用 JsonSerializer.SerializeToUtf8Bytes 方法：
			byte[] jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(weatherForecast);
		}


		private class WeatherForecast2
		{
			public DateTimeOffset Date { get; set; }
			public int TemperatureCelsius { get; set; }
			public string? Summary { get; set; }
			public string? SummaryField;
			public IList<DateTimeOffset>? DatesAvailable { get; set; }
			public Dictionary<string, HighLowTemps>? TemperatureRanges { get; set; }
			public string[]? SummaryWords { get; set; }
		}
		private class HighLowTemps
		{
			public int High { get; set; }
			public int Low { get; set; }
		}
		[Test]
		public void JsonSerializer_序列化2Test()
		{
			var weatherForecast = new WeatherForecast2
			{
				Date = DateTime.Parse("2019-08-01"),
				TemperatureCelsius = 25,
				Summary = "Hot",
				SummaryField = "Hot",
				DatesAvailable = new List<DateTimeOffset>()
					{ DateTime.Parse("2019-08-01"), DateTime.Parse("2019-08-02") },
				TemperatureRanges = new Dictionary<string, HighLowTemps>
				{
					["Cold"] = new HighLowTemps { High = 20, Low = -10 },
					["Hot"] = new HighLowTemps { High = 60, Low = 20 }
				},
				SummaryWords = new[] { "Cool", "Windy", "Humid" }
			};

			var options = new JsonSerializerOptions { WriteIndented = true };
			string jsonString = JsonSerializer.Serialize(weatherForecast, options);

			Console.WriteLine(jsonString);
		}

		[Test]
		public async Task Json_保存文件()
		{
			var weatherForecast = new WeatherForecast
			{
				Date = DateTime.Parse("2019-08-01"),
				TemperatureCelsius = 25,
				Summary = "Hot"
			};

			string fileName = "WeatherForecast.json";
			using FileStream createStream = File.Create(fileName);
			await JsonSerializer.SerializeAsync(createStream, weatherForecast);
			await createStream.DisposeAsync();

			Console.WriteLine(File.ReadAllText(fileName));
		}
		private class WeatherForecast
		{
			public DateTimeOffset Date { get; set; }
			public int TemperatureCelsius { get; set; }
			public string? Summary { get; set; }
		}


		[Test]
		public void JsonSerializer_序列化1Test()
		{
			var weatherForecast = new WeatherForecast
			{
				Date = DateTime.Parse("2019-08-01"),
				TemperatureCelsius = 25,
				Summary = "Hot"
			};
			string jsonString = JsonSerializer.Serialize(weatherForecast);
		}

	}
}
