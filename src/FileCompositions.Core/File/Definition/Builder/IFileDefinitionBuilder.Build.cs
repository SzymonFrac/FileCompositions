using FileCompositions.Core.File.Options;
using FileCompositions.Core.Quality.Ownership;
using FileCompositions.Core.Quality.Placement;

namespace FileCompositions.Core.File.Definition.Builder;

//public partial interface IFileDefinitionBuilder<TOwnership, TPlacement, TOptions>
//    where TOwnership : DefinitionOwnership
//    where TPlacement : DefinitionPlacement
//    where TOptions : IFileOptions<TOptions>
//{

//    //internal ResourceSchemaFileRegisterRequest<TOwnership, TPlacement, TDefinition> Build(DirectoryDefinitionKey directoryKey);
//}

// 1.
// INoneBuilder<S, R>
// INoneBuilder<TNO, TNP>
// ISomeBuilder<TNO, TNP>
// changing quality changes back to:
// INoneBuilder<TNNO, TNNP>

// 2.
// IFileBuilder<S, R, TOptions>
// IFileBuilder<TO, TP, TNewOptions>
// return
// wrap via extensions:
// JsonBuilder.Create(inner: IFileBuilder<TO, TP, TJsonOptions<T>>)
// then IFileBuilder preserves generics and defers it untill its wrapped
// But:
// INoneFileBuilder is kinda pointless.
// also have to wrap as decorator...
// kind of implies that one is an intermediate object - but still both are builders...
// Also, wouldn't I still get generic extension issue from Json<T>?

// Unless I say that INone is used to not allow further specialization?
// Cause then I can reduce the generics if I don't allow TOptions...
// Because why would you want to specialize twice anyway...
// Although then I would need to define two Quality methods on:
// IFileBuilder<TO, TP> and IFileBuilder<TO, TP, TOptions>
// Cause <TO,TP,TOp> can't inherit <TO,TP> casue you back down
// but it's still better than reducing down completely.

// So I guess I deal with wrapping it...
// maybe I'm fine with it really