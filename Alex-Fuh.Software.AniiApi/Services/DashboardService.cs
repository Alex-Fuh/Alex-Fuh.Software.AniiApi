using System.Text;
using System.Text.Json;
using Alex_Fuh.Software.AniiApi.Services.Interfaces;

namespace Alex_Fuh.Software.AniiApi.Services;

public class DashboardService : IDashboardService
{
    public async Task<string> LoadingTitelsForFrontPageAsync()
    {
        var loadQuery = @"query ($page: Int, $perPage: Int) {
              Page(page: $page, perPage: $perPage) {
                media(type: ANIME, sort: SCORE_DESC) {
                  title { romaji english }
                  averageScore
                  popularity
                }
              }
            }";
        
        var requestBody = new
        {
            query = loadQuery,
            variables = new
            {
                page = 1,
                perPage = 30
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