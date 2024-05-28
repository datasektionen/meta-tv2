namespace Meta_TV2_DataLayer;

/// <summary>
/// This class is used for transfering fetched data from datalayer to businesslayer. If the datalayer returns data from database, then 'HasValue' is set to true
/// and 'Value' contains the fetched data. The method 'Result' is executed with the fetched data passed as argument. If datalayer does not return data from database
/// (no data found in database) the fields are set to false and null respectively. The method 'Empty' is executed if no data is fetched.
/// </summary>
/// <typeparam name="T">The entity class this object contains an instance of</typeparam>
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

