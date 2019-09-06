using System;
using Microsoft.Extensions.DependencyInjection;
using Q101.ServiceCollectionExtensions.Enums;

namespace Q101.ServiceCollectionExtensions.Helpers
{
    /// <summary>
    /// Binding wrapper
    /// </summary>
    internal class AddBindingWrapper
    {
        private readonly AddScopedWrapper _addScopedWrapper;

        private readonly AddTransientWrapper _addTransientWrapper;

        private readonly AddSingletonWrapper _addSingletonWrapper;
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="addScopedWrapper"></param>
        public AddBindingWrapper(AddScopedWrapper addScopedWrapper,
                                 AddTransientWrapper addTransientWrapper,
                                 AddSingletonWrapper addSingletonWrapper)
        {
            _addScopedWrapper = addScopedWrapper;

            _addTransientWrapper = addTransientWrapper;

            _addSingletonWrapper = addSingletonWrapper;
        }
        /// <summary>
        /// Add bind service with options
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="type">Binding type</param>
        /// <param name="implementType">Type which implemented</param>
        /// <param name="options">Life time binding option</param>
        /// <param name="propsAutoWired">Use option auto wired property</param>
        internal void Add(IServiceCollection services,
                                 Type type,
                                 Type implementType,
                                 LifeTimeOptions options,
                                 bool propsAutoWired)
        {
            switch (options)
            {
                case LifeTimeOptions.Scoped:
                    _addScopedWrapper.Add(services, type, implementType, propsAutoWired);
                    break;
                case LifeTimeOptions.Singleton:
                    _addSingletonWrapper.Add(services, type, implementType, propsAutoWired);
                    break;
                default:
                    _addTransientWrapper.Add(services, type, implementType, propsAutoWired);
                    break;
            }
        }
    }
}
