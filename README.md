# q101-net-core22-service-collection-extensions

This is an assembly extension for the type of IServiceCollection platform of dot net core version 2.2 and higher

 To install this assembly (class library) on the package manager console tab, run the following command:
```bash

Install-Package Q101.ServiceCollectionExtensions -Version 1.0.3

```

[see more..](https://www.nuget.org/packages/Q101.ServiceCollectionExtensions "")

### How to use it?

#### Example:

```cs
    ...
    
        public static void RegisterServices(this IServiceCollection services)
        {
            services.RegisterAssemblyTypes(typeof(ITypeInterface).Assembly)
                .Where(t => t.Name.EndsWith("EndNameOfType") 
                        && t.GetInterfaces()
                            .Any(ti => ti.Name == typeof(ITypeInterface).Name))
                .AsScoped()    // Similarly Like As services.AddScoped(T1, T2)
                .PropertiesAutowired() // Set properties values                
                .Bind();        
    ...

```