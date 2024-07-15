using System.Collections.Generic;
using System;

public sealed class ServiseLocator
{
    public static ServiseLocator instance { get; private set; }

    public ServiseLocator()
    {
        if(instance != null)
            throw new Exception($"The service has already been initialized!");

        instance = this;
    }

    private readonly Dictionary<Type, object> services = new();

    public void AddService<T>(T service)
    {
        services.Add(typeof(T), service);
    }

    public T GetService<T>()
    {
        if(!services.ContainsKey(typeof(T)))
            throw new Exception($"Service of type {typeof(T)} is not found!");

        return (T)services[typeof(T)];
    }
}