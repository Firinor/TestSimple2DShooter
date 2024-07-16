using System;

public class ReactiveValue<T>
{
    private T value;
    public T Value
    {
        get
        {
            return this.value;
        }
        set
        {
            this.value = value;
            OnValueChange?.Invoke(this.value);
        }
    }
    public Action<T> OnValueChange;

    public ReactiveValue() { }
    public ReactiveValue(T startValue)
    {
        value = startValue;
    }
}