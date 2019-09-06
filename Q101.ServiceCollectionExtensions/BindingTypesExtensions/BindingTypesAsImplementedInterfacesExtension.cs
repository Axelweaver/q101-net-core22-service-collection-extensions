namespace Q101.ServiceCollectionExtensions.BindingTypesExtensions
{
    /// <summary>
    /// Extension for BindingTypes type use option "AsImplementedInterfaces"
    /// </summary>
    public static class BindingTypesAsImplementedInterfacesExtension
    {
        /// <summary>
        /// Use option "AsImplementedInterfaces"
        /// </summary>
        /// <param name="bindingTypes"></param>
        /// <returns></returns>
        public static BindingTypes AsImplementedInterfaces(this BindingTypes bindingTypes)
        {
            bindingTypes.IsImplementByInterface = true;

            return bindingTypes;
        }
    }
}
