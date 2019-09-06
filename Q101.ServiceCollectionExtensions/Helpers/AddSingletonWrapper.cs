using System;
using Microsoft.Extensions.DependencyInjection;

namespace Q101.ServiceCollectionExtensions.Helpers
{
    /// <summary>
    /// Wrapper fot singleton services bindings
    /// </summary>
    internal class AddSingletonWrapper
    {
        private readonly ImplementationFactoryHelper _implementationFactoryHelper;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="implementationFactoryHelper"></param>
        internal AddSingletonWrapper(ImplementationFactoryHelper implementationFactoryHelper)
        {
            _implementationFactoryHelper = implementationFactoryHelper;
        }

        /// <summary>
        /// Add singleton bind for type
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
                    services.AddSingleton(type,
                        provider =>
                            _implementationFactoryHelper.PropsAutoWired(provider, type));
                }
                else
                {
                    services.AddSingleton(type);
                }
            }
            else
            {
                if (propsAutoWired)
                {
                    services.AddSingleton(type,
                        provider =>
                            _implementationFactoryHelper.PropsAutoWired(provider, implementType));
                }
                else
                {
                    services.AddSingleton(type, implementType);
                }
            }
        }
    }
}
