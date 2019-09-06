using Q101.ServiceCollectionExtensions.Enums;

namespace Q101.ServiceCollectionExtensions.BindingTypesExtensions
{
    /// <summary>
    /// Extension for BindingTypes for scoped lifetime
    /// </summary>
    public static class BindingTypesAddScopedExtension
    {
        /// <summary>
        /// Use scoped lifetime
        /// </summary>
        /// <param name="bindingTypes">Binding types options</param>
        /// <returns></returns>
        public static BindingTypes AddScoped(this BindingTypes bindingTypes)
        {
            bindingTypes.LifeTimeOptions = LifeTimeOptions.Scoped;

            return bindingTypes;
        }
    }
}
