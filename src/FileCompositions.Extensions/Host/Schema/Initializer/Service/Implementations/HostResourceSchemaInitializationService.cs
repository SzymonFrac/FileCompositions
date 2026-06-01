using Microsoft.Extensions.Hosting;

namespace FileCompositions.Extensions.Host.Schema.Initializer.Service.Implementations;

internal sealed class HostResourceSchemaInitializationService(IEnumerable<IHostResourceSchemaInitializer> initializers, IServiceProvider services) : IHostedService
{
    private readonly IEnumerable<IHostResourceSchemaInitializer> _initializers = initializers;
    private readonly IServiceProvider _services = services;

    public async Task StartAsync(CancellationToken cancellationToken = default)
    {
        foreach (var initializer in _initializers)
            await initializer.InitializeAsync(_services, cancellationToken).ConfigureAwait(false);
    }

    public Task StopAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
}
