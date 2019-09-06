using Microsoft.Extensions.DependencyInjection;

namespace Q101.ServiceCollectionExtensions.ServiceCollectionExtensions
{
    /// <summary>
    /// Extension for IServiceCollection type for bind two types with options
    /// </summary>
    public  static class ServiceCollectionTwoTypesExtension
    {
        /// <summary>
        /// bind two types with options
        /// </summary>
        /// <typeparam name="T">Interface or base type</typeparam>
        /// <typeparam name="TImplemented"></typeparam>
        /// <param name="services">Implementing type</param>
        /// <returns></returns>
        public static BindingTypes RegisterTypes<T, TImplemented>(this IServiceCollection services)
        {
            var bindingTypes = new BindingTypes
            {
                Services = services,

                SingleType = typeof(T),

                ImplementType = typeof(TImplemented)
            };

            return bindingTypes;
        }
    }
}
