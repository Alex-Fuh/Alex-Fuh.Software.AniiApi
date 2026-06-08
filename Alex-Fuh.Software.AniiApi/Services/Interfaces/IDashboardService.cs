using Alex_Fuh.Software.AniiApi.Dto;

namespace Alex_Fuh.Software.AniiApi.Services.Interfaces;

public interface IDashboardService
{
    public Task<LoadFrontPageResponse> LoadingTitelsForFrontPageAsync(int from, int to);
}