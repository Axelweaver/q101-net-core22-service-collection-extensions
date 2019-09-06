using System;
using Microsoft.Extensions.DependencyInjection;

namespace Q101.ServiceCollectionExtensions.Helpers
{
    /// <summary>
    /// Wrapper fot scope services bindings
    /// </summary>
    internal class AddScopedWrapper
    {
        /// <summary>
        /// Add scope bind for type
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="type">Binding type</param>
        /// <param name="implementType">Type which implemented</param>
        /// <param name="propsAutoWired">Use option auto wired property</param>
        internal static void Add(IServiceCollection services,
                                 Type type,
                                 Type implementType,
                                 bool propsAutoWired)
        {
            if (implementType == null)
            {
                if (propsAutoWired)
                {
                    services.AddScoped(type,
                        provider =>
                            ImplementationFactoryHelper.PropsAutoWired(provider, type));
                }
                else
                {
                    services.AddScoped(type);
                }
            }
            else
            {
                if (propsAutoWired)
                {
                    services.AddScoped(type,
                        provider =>
                            ImplementationFactoryHelper.PropsAutoWired(provider, implementType));
                }
                else
                {
                    services.AddScoped(type, implementType);
                }
            }
        }
    }
}
