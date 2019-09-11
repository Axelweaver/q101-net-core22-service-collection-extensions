# q101-net-core22-service-collection-extensions

This is an assembly extension for the type of IServiceCollection platform of dot net core version 2.2 and higher

 To install this assembly (class library) on the package manager console tab, run the following command:
```bash

Install-Package Q101.ServiceCollectionExtensions -Version 1.0.4

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
            services.RegisterAssemblyTypesByName(typeof(IStudentRepository).Assembly,
                name => name.EndsWith("Repository")) // Condition for name of type
                .AsScoped()    // Similarly Like As services.AddScoped(T1, T2)
                // Set binding like as services.AddScoped<IRepository, Repository>();
                .AsImplementedInterfaces()                 
                .Bind();
     

```
**Conditions**

```cs
/* 
    The selection of types from the specified assembly occurs with the preliminary condition 
    that this is not an interface, and then the remaining specified conditions apply.
*/

    .Where(Func<Type,bool> func) // - condition for types of the previously specified assembly

    .WhereTypeName(Func<string, bool> nameComparer) // - condition for name of types
    
```

**Options**

```cs

    .PropertiesAutowired() /* - Automatically bind types to the properties of the specified types
                             with an available setter. Types that were specified for bindings 
                             are bound to properties. */
    
    .AsImplementedInterfaces() /* -  The first interface of each type from which it is inherited 
                                is searched, and the type is specified as an
                                 implementation of this interface. */
    
```

**Life time of dependency**
```cs

    .AsScoped()   /*  - for each request its own service object is created. 
                    That is, if during one request there are several calls to the same service, 
                    then all of these calls will use the same service object. */

    .AsTransient() /* - every time you access the service, a new service object is created. 
                    During one request, there may be several calls to the service; 
                    accordingly, each call will create a new object. 
                    Such a life cycle model is best suited for lightweight services that 
                    do not store state data.*/

    .AsSingleton() /* - the service object is created the first time it is accessed, 
                        all subsequent requests use the same previously 
                        created service object.*/


    .Bind() /* For end fo binding dependencies, it is always necessary 
                to execute the .Bind() method at the very end after all conditions. */

```


