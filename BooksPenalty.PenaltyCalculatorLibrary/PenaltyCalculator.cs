using BooksPenalty.PenaltyCalculatorLibrary.ApiResponse;
using Newtonsoft.Json;
using System.Globalization;

namespace BooksPenalty.PenaltyCalculatorLibrary;

public static class PenaltyCalculator
{
	private const string API_URL = "https://api.apilayer.com/exchangerates_data/";
	private const string API_KEY = "v4Ls7It5qsgOPrXWjbWVRpBzzomZEVt4";

	public async static Task<decimal> Calculate(DateTime start, DateTime end, string country)
	{
		var days = GetBusinessDays(start, end);
		try
		{
			var region = new RegionInfo(country);
			var rate = await GetCurrencyRateFromApi(region.ISOCurrencySymbol, "AED");
			return (decimal)days * rate;
		}
		catch (Exception ex)
		{

		}
		return 5;
	}


	private static double GetBusinessDays(DateTime startD, DateTime endD)
	{
		double calcBusinessDays =
			1 + ((endD - startD).TotalDays * 5 -
					 (startD.DayOfWeek - endD.DayOfWeek) * 2) / 7;

		if (endD.DayOfWeek == DayOfWeek.Saturday) calcBusinessDays--;
		if (startD.DayOfWeek == DayOfWeek.Sunday) calcBusinessDays--;

		return calcBusinessDays;
	}

	private async static Task<decimal> GetCurrencyRateFromApi(string to, string from)
	{
		var parameters = $"convert?to={to}&from={from}&amount={1}";
		var client = new HttpClient();
		client.BaseAddress = new Uri(API_URL);
		client.DefaultRequestHeaders.Add("apikey", API_KEY);
		var response = await client.GetAsync(parameters);
		var data = await response.Content.ReadAsStringAsync();
		var obj = JsonConvert.DeserializeObject<GetConvertDto>(data);
		return obj.result;
	}
}