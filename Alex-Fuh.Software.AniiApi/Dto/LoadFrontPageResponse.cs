using System.Text.Json.Serialization;

namespace Alex_Fuh.Software.AniiApi.Dto;

public class LoadFrontPageResponse
{
    [JsonPropertyName("data")]
    public Data Data { get; set; }
}

public class Data
{
    [JsonPropertyName("Page")]
    public Page Page { get; set; }
}

public class Page
{
    [JsonPropertyName("media")]
    public List<MediaDto> Media { get; set; }
}

public class MediaDto
{
    [JsonPropertyName("title")]
    public TitleDto? Title { get; set; }
    [JsonPropertyName("averageScore")]
    public int ? AverageScore { get; set; }
    [JsonPropertyName("popularity")]
    public int ? Popularity { get; set; }
}

public class TitleDto
{
    [JsonPropertyName("romaji")]
    public string? Romaji { get; set; }
    [JsonPropertyName("english")]
    public string? English { get; set; }
}
