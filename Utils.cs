using System.Net.Http.Json;
using System.Text.RegularExpressions;

namespace PinSalvareBot;

public static class Utils
{

	public static async Task<PinterestApiResponse?> GetVideoUrlFromApiAsync(string? pinUrl)
	{
		var configurationModel = ConfigurationManager.Configure();

		using HttpClient client = new HttpClient();

		var request = new HttpRequestMessage
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri($"{configurationModel.ApiEndpoint}?url={pinUrl}"),
			Headers =
			{
				{ "x-rapidapi-key", configurationModel.ApiHeaderKey },
				{ "x-rapidapi-host", configurationModel.ApiHeaderHost },
			},
		};

		using var response = await client.SendAsync(request);

		response.EnsureSuccessStatusCode();

		var fullData = await response.Content.ReadFromJsonAsync<PinterestApiResponse>();

		return fullData;
	}


	public static bool ValidatePinLink(string pinLink)
	{
		string urlPattern = @"^https?:\/\/(www\.)?(pinterest\.([a-z]{2,6}\.)?[a-z]{2,6}|pin\.it)\/[^\s]*$";

		return Regex.IsMatch(pinLink, urlPattern, RegexOptions.IgnoreCase);
	}
}
