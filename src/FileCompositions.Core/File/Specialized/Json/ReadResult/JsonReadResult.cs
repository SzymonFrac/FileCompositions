using FileCompositions.Core.File.Specialized.Json.ReadResult.Implementations;
using System.Diagnostics;

namespace FileCompositions.Core.File.Specialized.Json.ReadResult;

public abstract record JsonReadResult<T>
{
    public static JsonReadResult<T> Some(T value) => new JsonSomeResult<T>(value);
    public static JsonReadResult<T> None => new JsonNoneResult<T>();
    public static JsonReadResult<T> Missing => new JsonMissingResult<T>();
    
    public static implicit operator JsonReadResult<T>(T? value) =>
        value is not null
            ? new JsonSomeResult<T>(value)
            : new JsonNoneResult<T>();
}

public static class JsonReadResult
{
    extension<T>(JsonReadResult<T> result)
    {
        public TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none, Func<TResult> missing) => result switch
        {
            JsonSomeResult<T> v => some(v.Value),
            JsonNoneResult<T> => none(),
            JsonMissingResult<T> => missing(),
            _ => throw new UnreachableException()
        };
        public void Match(Action<T> some, Action none, Action missing)
        {
            switch (result)
            {
                case JsonSomeResult<T> v:
                    some(v.Value);
                    break;
                case JsonNoneResult<T>:
                    none();
                    break;
                case JsonMissingResult<T>:
                    missing();
                    break;
            }
        }

        public JsonReadResult<TResult> Map<TResult>(Func<T, TResult> f) => result switch
        {
            JsonMissingResult<T> => new JsonMissingResult<TResult>(),
            JsonNoneResult<T> => new JsonNoneResult<TResult>(),
            JsonSomeResult<T> v => new JsonSomeResult<TResult>(f(v.Value)),
            _ => throw new UnreachableException()
        };

        public JsonReadResult<TResult> Bind<TResult>(Func<T, JsonReadResult<TResult>> f) => result switch
        {
            JsonMissingResult<T> => new JsonMissingResult<TResult>(),
            JsonNoneResult<T> => new JsonNoneResult<TResult>(),
            JsonSomeResult<T> v => f(v.Value),
            _ => throw new UnreachableException()
        };


        public bool TryGetValue(out T? value)
        {
            if (result is JsonSomeResult<T> v)
            {
                value = v.Value;
                return true;
            }

            value = default;
            return false;
        }

        public T? GetValueOrDefault(T? defaultValue = default) => result switch
        {
            JsonSomeResult<T> v => v.Value,
            _ => defaultValue
        };
    }
}
