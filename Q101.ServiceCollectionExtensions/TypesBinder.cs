using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Q101.ServiceCollectionExtensions.Enums;
using Q101.ServiceCollectionExtensions.Helpers;

namespace Q101.ServiceCollectionExtensions
{
    /// <summary>
    /// Bindign types object for fluent api
    /// </summary>
    public sealed class TypesBinder
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

        private readonly SingleTypeBindHelper _singleTypeBindHelper;

        private readonly TypeRangeBindHelper _typeRangeBindHelper;

        /// <summary>
        /// ctor
        /// </summary>
        public TypesBinder()
        {
            var implementationFactoryHelper = new ImplementationFactoryHelper();
            
            var addScopedWrapper = new AddScopedWrapper(implementationFactoryHelper);

            var addTransientWrapper = new AddTransientWrapper(implementationFactoryHelper);

            var addSingletonWrapper = new AddSingletonWrapper(implementationFactoryHelper);

            var addBindingWrapper = new AddBindingWrapper(addScopedWrapper, addTransientWrapper, addSingletonWrapper);

            var implementByInterfaceHelper = new ImplementByInterfaceHelper(addBindingWrapper);

            _singleTypeBindHelper = new SingleTypeBindHelper(addBindingWrapper, implementByInterfaceHelper);

            _typeRangeBindHelper = new TypeRangeBindHelper(implementByInterfaceHelper, addBindingWrapper);            
        }

        /// <summary>
        /// Use scoped lifetime
        /// </summary>
        /// <returns></returns>
        public void AsScoped()
        {
            LifeTimeOptions = LifeTimeOptions.Scoped;
        }

        /// <summary>
        /// Use singleton lifetime
        /// </summary>
        public void AsSingleton()
        {
            LifeTimeOptions = LifeTimeOptions.Singleton;
        }

        /// <summary>
        /// Use transient lifetime
        /// </summary>
        public void AsTransient()
        {
            LifeTimeOptions = LifeTimeOptions.Transient;
        }

        /// <summary>
        /// Use option "AsImplementedInterfaces"
        /// </summary>
        public void AsImplementedInterfaces()
        {
            IsImplementByInterface = true;
        }

        /// <summary>
        /// Use option "PropertiesAutowired"
        /// </summary>
        public void PropertiesAutowired()
        {
            IsPropertiesAutoWired = true;
        }

        /// <summary>
        /// Filter assembly types by functor
        /// </summary>
        /// <param name="func"></param>
        public void Where(Func<Type, bool> func)
        {
            if (Assembly != null
                || Types != null && Types.Any())
            {
                Types =
                    Assembly != null
                    && (Types == null
                        || !Types.Any())
                        ? Assembly
                            .GetTypes()
                            .Where(func)
                            .ToArray()
                        : Types
                            .Where(func)
                            .ToArray();
            }
        }

        /// <summary>
        /// Filter assembly types by type name
        /// </summary>
        /// <param name="nameComparer"></param>
        public void WhereTypeName(Func<string, bool> nameComparer)
        {
            if (Assembly != null
                || Types != null && Types.Any())
            {
                Types =
                    Assembly != null
                    && (Types == null
                        || !Types.Any())
                        ? Assembly
                            .GetTypes()
                            .Where(t => nameComparer(t.Name))
                            .ToArray()
                        : Types
                            .Where(t => nameComparer(t.Name))
                            .ToArray();
            }
        }

        /// <summary>
        /// Bind types by options
        /// </summary>
        public  void Bind()
        {
            if (Assembly != null
                || Types != null && !Types.Any())
            {
                if (Types != null && !Types.Any())
                {
                    _typeRangeBindHelper.Bind(this);
                }
                else if (Assembly != null)
                {
                    Types = Assembly.GetTypes();

                    _typeRangeBindHelper.Bind(this);
                }
            }
            else if (SingleType != null)
            {
                _singleTypeBindHelper.Bind(this);
            }
        }
    }
}
