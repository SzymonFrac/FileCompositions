using FileCompositions.Core.FileResource.Builder.Implementations;
using FileCompositions.Core.FileResource.Specialized.Db.Builder;
using FileCompositions.Core.FileResource.Specialized.Db.Specialization.Builder.Extensions;
using FileCompositions.Extensions.Host.Schema.Resources.FileResource.Register.Definition;
using FileCompositions.Extensions.Host.Schema.Resources.FileResource.Register.Implementations;
using FileCompositions.Extensions.Host.Schema.Resources.FileResource.Register.Mux;

namespace FileCompositions.Extensions.Host.Schema.Resources.FileResource.Specialized.Db.Extensions;

public static class HostResourceSchemaDbRegisters
{
    extension(IHostResourceSchemaFileResourceRegisterMux mux)
    {
        public HostFileResourceRegisterDefinition AsDb(Action<IDbFileResourceBuilder> config) =>
            new((directoryKey, fileKey, baseConfig) =>
            {
                var baseBuilder = new FileResourceBuilder();
                baseConfig(baseBuilder);

                var dbBuilder = baseBuilder.ToDb();
                config(dbBuilder);
                var dbDescriptor = dbBuilder.BuildDescriptor(directoryKey);

                var dbRegister = new DbHostFileResourceRegister(fileKey, dbDescriptor);
                return dbRegister;
            });
        public HostFileResourceRegisterDefinition AsDb() =>
            new((directoryKey, fileKey, baseConfig) =>
            {
                var baseBuilder = new FileResourceBuilder();
                baseConfig(baseBuilder);

                var dbBuilder = baseBuilder.ToDb();
                var dbDescriptor = dbBuilder.BuildDescriptor(directoryKey);

                var dbRegister = new DbHostFileResourceRegister(fileKey, dbDescriptor);
                return dbRegister;
            });
    }
}
