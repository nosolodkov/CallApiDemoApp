using ApiHelpers;

namespace Apis.Sun;

public static class SunProcessor
{
    private const string Url = "https://api.sunrise-sunset.org/json?lat=36.7201600&lng=-4.4203400";

    public static async Task<SunModel> LoadSunInfo()
    {
        var url = Url;

        using var response = await ApiClient.Instance.Client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var model = await response.Content.ReadAsAsync<SunResultModel>();
            return model.Results;
        }

        throw new Exception(response.ReasonPhrase);
    }
}
