using ApiHelpers;

namespace Apis.Xkcd;

public static class ComicProcessor
{
    public static async Task<ComicModel> LoadComic()
    {
        return await LoadComic(0);
    }

    public static async Task<ComicModel> LoadComic(int comicNumber)
    {
        var url = comicNumber > 0 ?
            $"https://xkcd.com/{comicNumber}/info.0.json" :
            "https://xkcd.com/info.0.json";

        using var response = await ApiClient.Instance.Client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsAsync<ComicModel>();
        }

        throw new Exception(response.ReasonPhrase);
    }
}