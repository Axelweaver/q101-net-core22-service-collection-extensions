using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Q101.ServiceCollectionExtensions.ServiceCollectionExtensions
{
    /// <summary>
    /// Extension for IServiceCollection type for binding assembly types with options
    /// </summary>
    public static class ServiceCollectionAssemblyTypesExtension
    {
        /// <summary>
        /// Bind assembly types
        /// </summary>
        /// <param name="service">Service collection</param>
        /// <param name="assembly">Assembly</param>
        /// <returns></returns>
        public static BindingTypes RegisterAssemblyTypes(this IServiceCollection service, Assembly assembly)
        {
            var bindingTypes = new BindingTypes
            {
                Services = service,
                Assembly = assembly
            };

            return bindingTypes;
        }
    }
}
