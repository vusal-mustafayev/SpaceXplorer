using System.Threading;

namespace Application.Infrastructure.Services;

public class SpaceXLaunchService : ISpaceXLaunchService
{
    private readonly HttpClient _httpClient;


    static DefaultContractResolver _contractResolver = new()
    {
        NamingStrategy = new SnakeCaseNamingStrategy()
    };

    JsonSerializerSettings _settings = new()
    {
        ContractResolver = _contractResolver,
        Formatting = Formatting.Indented
    };

    public SpaceXLaunchService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _httpClient.BaseAddress = new Uri("https://api.spacexdata.com/v3/launches");
    }

    public async Task<LaunchDto> GetLaunchByFlightNumberAsync(int flightNumber, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"?flight_number={flightNumber}", cancellationToken);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<List<LaunchDto>>(json, _settings).FirstOrDefault();
    }

    public async Task<PaginatedList<LaunchDto>> GetLaunchesAsync(int limit, int offset, CancellationToken cancellationToken, string rocketName = "")
    {
        string uri = "";      

        var response = await _httpClient.GetAsync(uri, cancellationToken);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        var items = JsonConvert.DeserializeObject<List<LaunchDto>>(json, _settings);

        if (!string.IsNullOrWhiteSpace(rocketName))
        {
            items = items.Where(x => x.Rocket.RocketName.ToLower().Contains(rocketName)).ToList();
        }

        return new PaginatedList<LaunchDto>(items, items.Count, offset, limit);
    }
}