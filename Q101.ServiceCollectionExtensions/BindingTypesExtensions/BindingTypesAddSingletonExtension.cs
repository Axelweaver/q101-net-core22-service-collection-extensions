using Q101.ServiceCollectionExtensions.Enums;

namespace Q101.ServiceCollectionExtensions.BindingTypesExtensions
{
    /// <summary>
    /// Extension for BindingTypes for singleton lifetime
    /// </summary>
    public static class BindingTypesAddSingletonExtension
    {
        /// <summary>
        /// Use singleton lifetime
        /// </summary>
        /// <param name="bindingTypes">Binding types options</param>
        /// <returns></returns>
        public static BindingTypes AddSingleton(this BindingTypes bindingTypes)
        {
            bindingTypes.LifeTimeOptions = LifeTimeOptions.Singleton;

            return bindingTypes;
        }
    }
}
