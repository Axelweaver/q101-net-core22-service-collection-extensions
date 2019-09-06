namespace Q101.ServiceCollectionExtensions.Helpers
{
    /// <summary>
    /// Bind helper for range types
    /// </summary>
    internal class TypeRangeBindHelper
    {
        /// <summary>
        /// Bind range types
        /// </summary>
        /// <param name="bindingTypes"></param>
        internal static void Bind(BindingTypes bindingTypes)
        {
            foreach (var type in bindingTypes.Types)
            {
                if (bindingTypes.IsImplementByInterface)
                {
                    ImplementByInterfaceHelper.Add(
                        bindingTypes.Services,
                        type,
                        bindingTypes.LifeTimeOptions,
                        bindingTypes.IsPropertiesAutoWired);
                }
                else
                {
                    AddBindingWrapper.Add(
                        bindingTypes.Services,
                        type,
                        null,
                        bindingTypes.LifeTimeOptions,
                        bindingTypes.IsPropertiesAutoWired);
                }
            }
        }
    }
}
