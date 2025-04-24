namespace MadridEmt.Entities.Enumerations;

internal abstract class MadridEmtEnumeration<TKey, TValue>
{
    internal TKey Key { get; private set; }
    internal TValue Value { get; private set; }

    protected internal MadridEmtEnumeration(TKey key, TValue value)
    {
        Key = key;
        Value = value;
    }
}

