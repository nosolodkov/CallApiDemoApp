using System.Net.Http.Headers;

namespace ApiHelpers;

public sealed class ApiClient
{
    #region Singleton Pattern Implementation

    private static readonly Lazy<ApiClient> _instance = new(() => new ApiClient());

    public static ApiClient Instance { get { return _instance.Value; } }

    private ApiClient()
    {
        Client = new HttpClient();
        Client.DefaultRequestHeaders.Accept.Clear();
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    #endregion

    public HttpClient Client { get; }
}