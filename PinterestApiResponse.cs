using System;
using System.Text.Json.Serialization;

namespace PinSalvareBot;

public class PinterestApiResponse
{
	[JsonPropertyName("success")]
	public bool Success { get; set; }
	[JsonPropertyName("type")]
	public string? Type { get; set; }
	[JsonPropertyName("pinType")]
	public string? PinType { get; set; }
	[JsonPropertyName("version")]
	public string? Version { get; set; }
	[JsonPropertyName("data")]
	public Data? Data { get; set; }
}


public class Data
{
	[JsonPropertyName("pages")]
	public object? Pages { get; set; }
	[JsonPropertyName("width")]
	public int? Width { get; set; }
	[JsonPropertyName("height")]
	public int? Height { get; set; }
	[JsonPropertyName("duration")]
	public int? Duration { get; set; }
	[JsonPropertyName("url")]
	public string? Url { get; set; }
	[JsonPropertyName("thumbnail")]
	public string? Thumbnail { get; set; }
	[JsonPropertyName("title")]
	public string? Title { get; set; }
	[JsonPropertyName("carousel")]
	public object? Carousel { get; set; }
}