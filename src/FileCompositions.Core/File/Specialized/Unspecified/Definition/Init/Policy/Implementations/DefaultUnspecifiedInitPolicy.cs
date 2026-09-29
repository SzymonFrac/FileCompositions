using FileCompositions.Core.File.Definition.Ext;
using FileCompositions.Core.Quality;
using System.Diagnostics;

namespace FileCompositions.Core.File.Specialized.Unspecified.Definition.Init.Policy.Implementations;

internal sealed partial class DefaultUnspecifiedInitPolicy<TOwnership, TPlacement> : IUnspecifiedInitPolicy<TOwnership, TPlacement>
    where TOwnership : Ownership
    where TPlacement : Placement
{
    public Func<CancellationToken, Task> GetPolicy(IUnspecifiedDefinition<TOwnership, TPlacement> init) => init switch
    {
        IUnspecifiedDefinition<Ownership.Internal, Placement.RequiredInRequired> sr => sr.InitDllAsync,
        IUnspecifiedDefinition<Ownership.External, Placement.RequiredInRequired> er => er.InitDllAsync,
        IUnspecifiedDefinition<Ownership.Internal, Placement.OptionalInRequired> so => so.InitDllAsync,
        IUnspecifiedDefinition<Ownership.External, Placement.OptionalInRequired> eo => eo.InitDllAsync,
        IUnspecifiedDefinition<Ownership.Internal, Placement.OptionalInOptional> soo => soo.InitDllAsync,
        IUnspecifiedDefinition<Ownership.External, Placement.OptionalInOptional> eoo => eoo.InitDllAsync,
        _ => throw new UnreachableException()
    };
}

internal static partial class DefaultUnspecifiedInitPolicy
{
    extension(IUnspecifiedDefinition<Ownership.Internal, Placement.RequiredInRequired> unspecified)
    {
        public Task InitDllAsync(CancellationToken cancellationToken = default) =>
            unspecified.InitAsync(cancellationToken);
    }

    extension(IUnspecifiedDefinition<Ownership.External, Placement.RequiredInRequired> unspecified)
    {
        public Task InitDllAsync(CancellationToken cancellationToken = default) =>
            unspecified.InitAsync(cancellationToken);
    }

    extension(IUnspecifiedDefinition<Ownership.Internal, Placement.OptionalInRequired> unspecified)
    {
        public Task InitDllAsync(CancellationToken cancellationToken = default) =>
            unspecified.InitAsync(cancellationToken);
    }

    extension(IUnspecifiedDefinition<Ownership.External, Placement.OptionalInRequired> unspecified)
    {
        public Task InitDllAsync(CancellationToken cancellationToken = default) =>
            unspecified.InitAsync(cancellationToken);
    }

    extension(IUnspecifiedDefinition<Ownership.Internal, Placement.OptionalInOptional> unspecified)
    {
        public Task InitDllAsync(CancellationToken cancellationToken = default) =>
            unspecified.InitAsync(cancellationToken);
    }

    extension(IUnspecifiedDefinition<Ownership.External, Placement.OptionalInOptional> unspecified)
    {
        public Task InitDllAsync(CancellationToken cancellationToken = default) =>
            unspecified.InitAsync(cancellationToken);
    }
}
