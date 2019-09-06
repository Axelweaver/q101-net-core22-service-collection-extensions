namespace Q101.ServiceCollectionExtensions.Helpers
{
    /// <summary>
    /// Bind helper for range types
    /// </summary>
    internal class TypeRangeBindHelper
    {
        private readonly ImplementByInterfaceHelper _implementByInterfaceHelper;

        private readonly AddBindingWrapper _addBindingWrapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="implementByInterfaceHelper"></param>
        /// <param name="addBindingWrapper"></param>
        internal TypeRangeBindHelper(ImplementByInterfaceHelper implementByInterfaceHelper, 
                                     AddBindingWrapper addBindingWrapper)
        {
            _implementByInterfaceHelper = implementByInterfaceHelper;

            _addBindingWrapper = addBindingWrapper;
        }

        /// <summary>
        /// Bind range types
        /// </summary>
        /// <param name="bindingTypes"></param>
        internal void Bind(TypesBinder bindingTypes)
        {
            foreach (var type in bindingTypes.Types)
            {
                if (bindingTypes.IsImplementByInterface)
                {
                    _implementByInterfaceHelper.Add(
                        bindingTypes.Services,
                        type,
                        bindingTypes.LifeTimeOptions,
                        bindingTypes.IsPropertiesAutoWired);
                }
                else
                {
                    _addBindingWrapper.Add(
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
