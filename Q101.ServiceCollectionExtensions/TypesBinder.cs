using System;
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
        /// Comparer for name of type
        /// </summary>
        internal Func<string, bool> NameComparer { get; set; }

        /// <summary>
        /// Comparer for type
        /// </summary>
        internal Func<Type, bool> TypeComparer { get; set; }

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
        public TypesBinder AsScoped()
        {
            LifeTimeOptions = LifeTimeOptions.Scoped;

            return this;
        }

        /// <summary>
        /// Use singleton lifetime
        /// </summary>
        public TypesBinder AsSingleton()
        {
            LifeTimeOptions = LifeTimeOptions.Singleton;

            return this;
        }

        /// <summary>
        /// Use transient lifetime
        /// </summary>
        public TypesBinder AsTransient()
        {
            LifeTimeOptions = LifeTimeOptions.Transient;

            return this;
        }

        /// <summary>
        /// Use option "AsImplementedInterfaces"
        /// </summary>
        public TypesBinder AsImplementedInterfaces()
        {
            IsImplementByInterface = true;

            return this;
        }

        /// <summary>
        /// Use option "PropertiesAutowired"
        /// </summary>
        public TypesBinder PropertiesAutowired()
        {
            IsPropertiesAutoWired = true;

            return this;
        }

        /// <summary>
        /// Filter assembly types by functor
        /// </summary>
        /// <param name="func"></param>
        public TypesBinder Where(Func<Type, bool> func)
        {
            TypeComparer = func;

            return this;
        }

        /// <summary>
        /// Filter assembly types by type name
        /// </summary>
        /// <param name="nameComparer"></param>
        public TypesBinder WhereTypeName(Func<string, bool> nameComparer)
        {
            NameComparer = nameComparer;

            return this;
        }

        /// <summary>
        /// Bind types by options
        /// </summary>
        public void Bind()
        {
            if (Assembly != null)
            {
                var types = Assembly
                    .GetTypes()
                    .Where(t => !t.IsInterface
                        && (TypeComparer == null || TypeComparer(t))
                        && (NameComparer == null || NameComparer(t.Name)))
                    .ToArray();

                _typeRangeBindHelper.Bind(this, types);                        
            }
            else if (SingleType != null)
            {
                _singleTypeBindHelper.Bind(this);
            }
        }
    }
}
