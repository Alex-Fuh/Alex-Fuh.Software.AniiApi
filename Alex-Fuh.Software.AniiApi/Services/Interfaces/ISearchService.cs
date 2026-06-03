namespace Alex_Fuh.Software.AniiApi.Services.Interfaces;

public interface ISearchService
{
    public Task<string> SearchAsync(string query);
}