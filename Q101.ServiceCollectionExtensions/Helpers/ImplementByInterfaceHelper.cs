using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Q101.ServiceCollectionExtensions.Enums;

namespace Q101.ServiceCollectionExtensions.Helpers
{
    /// <summary>
    /// Add implement by interface helper
    /// </summary>
    internal class ImplementByInterfaceHelper
    {
        private readonly AddBindingWrapper _addBindingWrapper;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="addBindingWrapper"></param>
        internal ImplementByInterfaceHelper(AddBindingWrapper addBindingWrapper)
        {
            _addBindingWrapper = addBindingWrapper;
        }

        /// <summary>
        /// Add service bind by implemented interface
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="type">Binding type</param>
        /// <param name="options">Life time binding option</param>
        /// <param name="propertyAutoWired">Use option auto wired property</param>
        internal void Add(IServiceCollection services,
                                 Type type,
                                 LifeTimeOptions options,
                                 bool propertyAutoWired)
        {
            var implementedInterface = 
                        type.GetInterfaces()
                            .FirstOrDefault();

            _addBindingWrapper.Add(services, 
                                   implementedInterface, 
                                   type,
                                   options, 
                                   propertyAutoWired);
        }
    }
}
