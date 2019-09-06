using System;
using Microsoft.Extensions.DependencyInjection;

namespace Q101.ServiceCollectionExtensions.Helpers
{
    /// <summary>
    /// Wrapper fot transient services bindings
    /// </summary>
    internal class AddTransientWrapper
    {
        private readonly ImplementationFactoryHelper _implementationFactoryHelper;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="implementationFactoryHelper"></param>
        internal AddTransientWrapper(ImplementationFactoryHelper implementationFactoryHelper)
        {
            _implementationFactoryHelper = implementationFactoryHelper;
        }

        /// <summary>
        /// Add transient bind for type
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="type">Binding type</param>
        /// <param name="implementType">Type which implemented</param>
        /// <param name="propsAutoWired">Use option auto wired property</param>
        internal void Add(IServiceCollection services,
                                 Type type,
                                 Type implementType,
                                 bool propsAutoWired)
        {
            if (implementType == null)
            {
                if (propsAutoWired)
                {
                    services.AddTransient(type,
                        provider =>
                            _implementationFactoryHelper.PropsAutoWired(provider, type));
                }
                else
                {
                    services.AddTransient(type);
                }
            }
            else
            {
                if (propsAutoWired)
                {
                    services.AddTransient(type,
                        provider =>
                            _implementationFactoryHelper.PropsAutoWired(provider, implementType));
                }
                else
                {
                    services.AddTransient(type, implementType);
                }
            }
        }
    }
}
