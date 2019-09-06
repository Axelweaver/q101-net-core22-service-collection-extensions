namespace Q101.ServiceCollectionExtensions.BindingTypesExtensions
{
    /// <summary>
    /// Extension for BindingTypes for use option "PropertiesAutowired"
    /// </summary>
    public static class BindingTypesPropertiesAutowiredExtension
    {
        /// <summary>
        /// Use option "PropertiesAutowired"
        /// </summary>
        /// <param name="bindingTypes">Binding types options</param>
        /// <returns></returns>
        public static BindingTypes PropertiesAutowired(this BindingTypes bindingTypes)
        {
            bindingTypes.IsPropertiesAutoWired = true;

            return bindingTypes;
        }
    }
}
