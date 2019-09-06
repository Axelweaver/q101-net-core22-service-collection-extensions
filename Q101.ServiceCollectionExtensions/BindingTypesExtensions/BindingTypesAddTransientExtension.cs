using Q101.ServiceCollectionExtensions.Enums;

namespace Q101.ServiceCollectionExtensions.BindingTypesExtensions
{
    /// <summary>
    /// Extension for BindingTypes for scoped lifetime
    /// </summary>
    public static class BindingTypesAddTransientExtension
    {
        /// <summary>
        /// Use transient lifetime
        /// </summary>
        /// <param name="bindingTypes">Binding types options</param>
        /// <returns></returns>
        public static BindingTypes AddTransient(this BindingTypes bindingTypes)
        {
            bindingTypes.LifeTimeOptions = LifeTimeOptions.Transient;

            return bindingTypes;
        }
    }
}
