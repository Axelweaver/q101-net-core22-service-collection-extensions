using Microsoft.Extensions.DependencyInjection;

namespace Q101.ServiceCollectionExtensions.ServiceCollectionExtensions
{
    /// <summary>
    /// Extension for IServiceCollection type for bind single type with options
    /// </summary>
    public static class ServiceCollectionSingleTypeExtension
    {
        /// <summary>
        /// Bind single type as service with options
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="services">Service collection</param>
        /// <returns></returns>
        public static TypesBinder RegisterType<T>(this IServiceCollection services)
        {
            var bindingTypes = new TypesBinder
            {
                Services = services,

                SingleType = typeof(T)
            };

            return bindingTypes;
        }
    }
}
