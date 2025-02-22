using Microsoft.Extensions.DependencyInjection;
using System;

namespace DIFactory;

public class Factory<T> : IFactory<T> where T : class
{
    private readonly IServiceProvider _serviceProvider;

    public Factory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public T Create()
    {
        return _serviceProvider.GetRequiredService<T>();
    }
}