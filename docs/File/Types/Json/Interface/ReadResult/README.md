<h1 align="center">
  Json Read Result
</h1>

<p align="center">
  <i>A monad to represent some, none and missing values</i>
</p>

## Basics

In an optional json file the data could be some or none (null) values, but the file could also be missing.
`JsonReadResult` provides a way to separate between 'none' (null) and 'missing', since an `Option<T>`'s 'none' case would include missing.

### Type Definition

```csharp
public abstract record JsonReadResult<T>
```

#### Implementations

```chsarp
public sealed record JsonSomeResult<T>(T Value) : JsonReadResult<T>;
public sealed record JsonNoneResult<T> : JsonReadResult<T>;
public sealed record JsonMissingResult<T> : JsonReadResult<T>;
```

## Behaviour

### Properties

| Type                | Name    | Description                                             |
|---------------------|---------|---------------------------------------------------------|
| `JsonReadResult<T>` | None    | Static property that provides a new `JsonNoneResult`.   |
| `JsonReadResult<T>` | Missing | Static property that provides a new `JsonMissingResult` |

### Methods

| Return Type         | Name    | Description                                           |
|---------------------|---------|-------------------------------------------------------|
| `JsonReadResult<T>` | Some(T) | Static property that provides a new `JsonSomeResult`. |

### Extension Methods

| Return Type               | Name                                                           | Description                                               |
|---------------------------|----------------------------------------------------------------|-----------------------------------------------------------|
| `TResult`                 | Match<TResult>(Func<T, TResult>, Func<TResult>, Func<TResult>) | Matches to the corresponding case: some, none and missing |
| `void`                    | Match(Action<T>, Action, Action)                               | Matches to the corresponding case: some, none and missing |
| `JsonReadResult<TResult>` | Map<TResult>(Func<T, TResult>)                                 | Maps the result from T to TResult                         |
| `JsonReadResult<TResult>` | Bind<TResult>(Func<T, JsonReadResult<TResult>>)                | Binds the result from T to TResult                        |
| `bool`                    | TryGetValue(out T?)                                            | Gets the value using an out parameter, otherwise false    |
| `T?`                      | GetValueOrDefault(T?)                                          | Gets the value, or uses the default value provided        |

---

> [!IMPORTANT]
> The `JsonReadResult` was made have a functional monad to distinguish between the file missing and a default value.
> However, this should apply to any file, for example a text file or possibly an audio/image file too.
> \
> It could be that the `JsonReadResult` will be moved to a general FileReadResult, but this would likely be in the next major version.

