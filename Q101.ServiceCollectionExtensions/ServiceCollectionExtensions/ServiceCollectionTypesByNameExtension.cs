using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Q101.ServiceCollectionExtensions.ServiceCollectionExtensions
{
    /// <summary>
    /// Extension for IServiceCollection bind types by name
    /// </summary>
    public static class ServiceCollectionTypesByNameExtension
    {
        /// <summary>
        /// Bind types as services by name
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="assembly">Assembly of types</param>
        /// <param name="nameComparer">Type name comparer for bind</param>
        /// <returns></returns>
        public static BindingTypes RegisterAssemblyTypesByName(this IServiceCollection services, 
                                               Assembly assembly,
                                               Func<string, bool> nameComparer)
        {
            var types = assembly
                .GetTypes()
                .Where(t => !t.IsInterface
                            && nameComparer(t.Name));

            var bindingTypes = new BindingTypes
            {
                Types = types,
                Services = services
            };

            return bindingTypes;
        }
    }
}
