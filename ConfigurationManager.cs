using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace PinSalvareBot;

public static class ConfigurationManager
{
	public static ConfigurationModel Configure()
	{
		var configurationModel = new ConfigurationModel
		{
			BotToken = Environment.GetEnvironmentVariable("BotToken", EnvironmentVariableTarget.Process)
			?? throw new ArgumentNullException("BotToken"),
			ApiEndpoint = Environment.GetEnvironmentVariable("ApiEndpoint", EnvironmentVariableTarget.Process)
			?? throw new ArgumentNullException("ApiEndpoint"),
			ApiHeaderHost = Environment.GetEnvironmentVariable("ApiHeaderHost", EnvironmentVariableTarget.Process)
			?? throw new ArgumentNullException("ApiHeaderHost"),
			ApiHeaderKey = Environment.GetEnvironmentVariable("ApiHeaderKey", EnvironmentVariableTarget.Process)
			?? throw new ArgumentNullException("ApiHeaderKey"),
			AllowedUsers = Environment.GetEnvironmentVariable("AllowedUsers")?.Split(",").ToList()
			?? throw new ArgumentNullException("AllowedUsers")
		};

		return configurationModel;
	}
}

public class ConfigurationModel
{
	public string? BotToken { get; set; }
	public string? ApiEndpoint { get; set; }
	public string? ApiHeaderKey { get; set; }
	public string? ApiHeaderHost { get; set; }
	public List<string>? AllowedUsers { get; set; } = [];
}
