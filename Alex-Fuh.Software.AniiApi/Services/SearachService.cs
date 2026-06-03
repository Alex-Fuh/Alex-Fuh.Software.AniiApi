using System.Text;
using System.Text.Json;
using Alex_Fuh.Software.AniiApi.Services.Interfaces;

namespace Alex_Fuh.Software.AniiApi.Services;

public class SearchService : ISearchService
{
    public async Task<string> SearchAsync(string search)
    {
        var searchQuery = @"
        query ($search: String) {
          Media(search: $search, type: ANIME) {
            title {
              romaji
              english
              native
            }

            coverImage {
              extraLarge
            }

            bannerImage
            description
            genres
            episodes
            duration
            averageScore
            meanScore
            popularity
            siteUrl
          }
        }";

        var requestBody = new
        {
            query = searchQuery,
            variables = new
            {
                search = search
            }
        };

        var json = JsonSerializer.Serialize(requestBody);

        using var client = new HttpClient();

        var content = new StringContent(
            json,
            Encoding.UTF8,
            "application/json"
        );

        var response = await client.PostAsync("https://graphql.anilist.co", content);

        var responseBody = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseBody);
        }

        return responseBody;
    }
}