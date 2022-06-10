#if NETSTANDARD2_1
global using JsonConvert = Newtonsoft.Json.JsonConvert;
global using JsonNameAttribute = Newtonsoft.Json.JsonPropertyAttribute;
#else
global using JsonConvert = System.Text.Json.JsonSerializer;
global using JsonNameAttribute = System.Text.Json.Serialization.JsonPropertyNameAttribute;
#endif
global using static wrametools;
internal static class wrametools
{
	public static T Deserialize<T>(string json)
	{
#if NETSTANDARD2_1
		return JsonConvert.DeserializeObject<T>(json);
#else
		return JsonConvert.Deserialize<T>(json);
#endif
	}
}