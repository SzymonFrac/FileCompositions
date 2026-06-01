namespace FileCompositions.Extensions.Host.Schema.Initializer;

internal interface IHostResourceSchemaInitializer
{
    ValueTask InitializeAsync(IServiceProvider services, CancellationToken cancellationToken = default);
}
