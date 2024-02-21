namespace Meta_TV2_DataLayer;

public class Optional<T>
{
    public T Value { get; }
    public bool HasValue { get; }

    private Optional(T value, bool hasValue)
    {
        Value = value;
        HasValue = hasValue;
    }

    public static Optional<T> Result(T value) => new Optional<T>(value, true);
    public static Optional<T> Empty() => new Optional<T>(default, false);
}

