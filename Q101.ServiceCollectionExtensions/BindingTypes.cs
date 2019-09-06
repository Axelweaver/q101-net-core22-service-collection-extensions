using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Q101.ServiceCollectionExtensions.Enums;

namespace Q101.ServiceCollectionExtensions
{
    /// <summary>
    /// Bindign types object for fluent api
    /// </summary>
    public class BindingTypes
    {
        /// <summary>
        /// Single type for bind (or interface)
        /// </summary>
        internal Type SingleType { get; set; }

        /// <summary>
        /// Single implemented type
        /// </summary>
        internal Type ImplementType { get; set; }

        /// <summary>
        /// Assembly
        /// </summary>
        internal Assembly Assembly { get; set; }

        /// <summary>
        /// Collection types for bindings
        /// </summary>
        internal IEnumerable<Type> Types { get; set; }

        /// <summary>
        /// Services collection
        /// </summary>
        internal IServiceCollection Services { get; set; } 

        /// <summary>
        /// Options for lifetime bindings
        /// </summary>
        internal LifeTimeOptions LifeTimeOptions { get; set; } = LifeTimeOptions.Transient;

        /// <summary>
        /// Use option property auto wired for type
        /// </summary>
        internal bool IsPropertiesAutoWired { get; set; }

        /// <summary>
        /// Use option bind type interface implementation
        /// </summary>
        internal bool IsImplementByInterface { get; set; }
    }
}
