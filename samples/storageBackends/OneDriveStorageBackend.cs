using FileCompositions.Core.Storage.Address;
using FileCompositions.Core.Storage.Backend;
using FileCompositions.Core.Storage.Location;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace VidmoKsiegowy.StorageBackends;

// Your token provider for One Drive
public interface ITokenProvider
{
    Task<string> GetAccessTokenAsync(CancellationToken cancellationToken = default);
}

// Upload stream
internal sealed class OneDriveUploadStream : MemoryStream
{
    private readonly StorageLocation _location;
    private readonly HttpClient _httpClient;
    private readonly ITokenProvider _tokenProvider;
    private readonly CancellationToken _ct;

    public OneDriveUploadStream(
        StorageLocation location,
        HttpClient httpClient,
        ITokenProvider tokenProvider,
        CancellationToken ct)
    {
        _location = location;
        _httpClient = httpClient;
        _tokenProvider = tokenProvider;
        _ct = ct;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            UploadAsync().GetAwaiter().GetResult();
        }

        base.Dispose(disposing);
    }

    private async Task UploadAsync()
    {
        Position = 0;

        var token = await _tokenProvider.GetAccessTokenAsync(_ct);

        var request = new HttpRequestMessage(
            HttpMethod.Put,
            $"https://graph.microsoft.com/v1.0/me/drive/root:/{_location}:/content");

        request.Headers.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        request.Content = new StreamContent(this);

        var response = await _httpClient.SendAsync(request, _ct);
        response.EnsureSuccessStatusCode();
    }
}

// An implementation of what a OneDrive storage backend could look like
public class OneDriveStorageBackend(ITokenProvider tokenProvider, HttpClient httpClient) : IStorageBackend
{
    private readonly ITokenProvider _tokenProvider = tokenProvider;
    private readonly HttpClient _httpClient = httpClient;

    private async Task<HttpRequestMessage> CreateRequestAsync(
        HttpMethod method,
        string url,
        CancellationToken ct)
    {
        var token = await _tokenProvider.GetAccessTokenAsync(ct);

        var request = new HttpRequestMessage(method, url);
        request.Headers.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        return request;
    }

    private static string BuildItemUrl(StorageLocation location)
        => $"https://graph.microsoft.com/v1.0/me/drive/root:/{location}";

    private static string BuildContentUrl(StorageLocation location)
        => $"{BuildItemUrl(location)}:/content";

    public async Task<Stream> OpenReadAsync(StorageLocation location, CancellationToken cancellationToken = default)
    {
        var request = await CreateRequestAsync(
            HttpMethod.Get,
            BuildContentUrl(location),
            cancellationToken);

        var response = await _httpClient.SendAsync(
            request,
            HttpCompletionOption.ResponseHeadersRead,
            cancellationToken);

        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            throw new FileNotFoundException(location.ToString());

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStreamAsync(cancellationToken);
    }
    public Task<Stream> OpenWriteAsync(StorageLocation location, CancellationToken cancellationToken = default) =>
        Task.FromResult<Stream>(new OneDriveUploadStream(
            location,
            _httpClient,
            _tokenProvider,
            cancellationToken));
    public async ValueTask<bool> Exists(StorageLocation location, CancellationToken cancellationToken = default)
    {
        var request = await CreateRequestAsync(
            HttpMethod.Get,
            BuildItemUrl(location),
            cancellationToken);

        var response = await _httpClient.SendAsync(request, cancellationToken);

        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            return false;

        response.EnsureSuccessStatusCode();
        return true;
    }
    public async ValueTask CreateAddress(StorageAddress address, CancellationToken cancellationToken = default)
    {
        var token = await _tokenProvider.GetAccessTokenAsync(cancellationToken);

        var parentPath = new DirectoryInfo(address.ToString()).Parent?.ToString() ?? "";
        var folderName = address.Value.Split('/').Last();

        var request = new HttpRequestMessage(
            HttpMethod.Post,
            $"https://graph.microsoft.com/v1.0/me/drive/root:/{parentPath}:/children");

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        request.Content = new StringContent(
            System.Text.Json.JsonSerializer.Serialize(new
            {
                name = folderName,
                folder = new { },
                @microsoft_graph_conflictBehavior = "replace"
            }),
            System.Text.Encoding.UTF8,
            "application/json");

        var response = await _httpClient.SendAsync(request, cancellationToken);

        response.EnsureSuccessStatusCode();
    }
}
