using System;
using Microsoft.Extensions.DependencyInjection;
using Q101.ServiceCollectionExtensions.Enums;

namespace Q101.ServiceCollectionExtensions.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    internal class AddBindingWrapper
    {
        /// <summary>
        /// Add bind service with options
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="type">Binding type</param>
        /// <param name="implementType">Type which implemented</param>
        /// <param name="options">Life time binding option</param>
        /// <param name="propsAutoWired">Use option auto wired property</param>
        internal static void Add(IServiceCollection services,
                                 Type type,
                                 Type implementType,
                                 LifeTimeOptions options,
                                 bool propsAutoWired)
        {
            switch (options)
            {
                case LifeTimeOptions.Scoped:
                    AddScopedWrapper.Add(services, type, implementType, propsAutoWired);
                    break;
                case LifeTimeOptions.Singleton:
                    AddSingletonWrapper.Add(services, type, implementType, propsAutoWired);
                    break;
                default:
                    AddTransientWrapper.Add(services, type, implementType, propsAutoWired);
                    break;
            }
        }
    }
}
