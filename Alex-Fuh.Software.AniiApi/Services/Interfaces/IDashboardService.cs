namespace Alex_Fuh.Software.AniiApi.Services.Interfaces;

public interface IDashboardService
{
    public Task<string> LoadingTitelsForFrontPageAsync(int from, int to);
}