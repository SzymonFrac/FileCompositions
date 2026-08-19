namespace FileCompositions.Hosting.ResourceSchema.Initializer;

internal interface IHostResourceSchemaInitializer
{
    Task InitializeAsync(IServiceProvider services, CancellationToken cancellationToken = default);
}
