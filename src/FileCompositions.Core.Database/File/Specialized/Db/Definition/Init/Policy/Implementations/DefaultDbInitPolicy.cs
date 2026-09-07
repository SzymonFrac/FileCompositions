using FileCompositions.Core.File.Definition.Ext;
using FileCompositions.Core.Quality;
using System.Diagnostics;

namespace FileCompositions.Core.Database.File.Specialized.Db.Definition.Init.Policy.Implementations;

internal sealed partial class DefaultDbInitPolicy<TOwnership, TPlacement> : IDbInitPolicy<TOwnership, TPlacement>
    where TOwnership : Ownership
    where TPlacement : Placement
{
    public Func<CancellationToken, Task> GetPolicy(IDbDefinition<TOwnership, TPlacement> init) => init switch
    {
        IDbDefinition<Ownership.Internal, Placement.RequiredInRequired> sr => sr.InitDbAsync,
        IDbDefinition<Ownership.External, Placement.RequiredInRequired> er => er.InitDbAsync,
        IDbDefinition<Ownership.Internal, Placement.OptionalInRequired> so => so.InitDbAsync,
        IDbDefinition<Ownership.External, Placement.OptionalInRequired> eo => eo.InitDbAsync,
        IDbDefinition<Ownership.Internal, Placement.OptionalInOptional> soo => soo.InitDbAsync,
        IDbDefinition<Ownership.External, Placement.OptionalInOptional> eoo => eoo.InitDbAsync,
        _ => throw new UnreachableException()
    };
}

internal static partial class DefaultDbInitPolicy
{
    extension(IDbDefinition<Ownership.Internal, Placement.RequiredInRequired> init)
    {
        public Task InitDbAsync(CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension(IDbDefinition<Ownership.External, Placement.RequiredInRequired> init)
    {
        public Task InitDbAsync(CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension(IDbDefinition<Ownership.Internal, Placement.OptionalInRequired> init)
    {
        public Task InitDbAsync(CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension(IDbDefinition<Ownership.External, Placement.OptionalInRequired> init)
    {
        public Task InitDbAsync(CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension(IDbDefinition<Ownership.Internal, Placement.OptionalInOptional> init)
    {
        public Task InitDbAsync(CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }

    extension(IDbDefinition<Ownership.External, Placement.OptionalInOptional> init)
    {
        public Task InitDbAsync(CancellationToken cancellationToken = default) =>
            init.InitAsync(cancellationToken);
    }
}
