namespace FileCompositions.Hosting.ResourceSchema.Initializer;

internal interface IHostResourceSchemaInitializer
{
    ValueTask InitializeAsync(IServiceProvider services, CancellationToken cancellationToken = default);
}
