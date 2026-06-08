using System.Text;
using System.Text.Json;
using Alex_Fuh.Software.AniiApi.Dto;
using Alex_Fuh.Software.AniiApi.Services.Interfaces;

namespace Alex_Fuh.Software.AniiApi.Services;

public class DashboardService : IDashboardService
{
    public async Task<LoadFrontPageResponse> LoadingTitelsForFrontPageAsync(int from, int to)
    {
        var loadQuery = @"query ($page: Int, $perPage: Int) {
              Page(page: $page, perPage: $perPage) {
                media(type: ANIME, sort: SCORE_DESC) {
                  title { romaji english }
                  averageScore
                  popularity
                  coverImage {
                    extraLarge
                  }          
                }
              }
            }";
        
        var requestBody = new
        {
            query = loadQuery,
            variables = new
            {
                page = from,
                perPage = to
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

        if (!response.IsSuccessStatusCode)
        {
            var errorBody = await response.Content.ReadAsStringAsync();
            throw new Exception(errorBody);
        }

        return await response.Content
            .ReadFromJsonAsync<LoadFrontPageResponse>();
        
    }
}