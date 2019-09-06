using Microsoft.Extensions.DependencyInjection;

namespace Q101.ServiceCollectionExtensions.Helpers
{
    /// <summary>
    /// Helper for bind single type(types)
    /// </summary>
    internal class SingleTypeBindHelper
    {
        private readonly AddBindingWrapper _addBindingWrapper;

        private readonly ImplementByInterfaceHelper _implementByInterfaceHelper;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="addBindingWrapper"></param>
        /// <param name="implementByInterfaceHelper"></param>
        internal SingleTypeBindHelper(AddBindingWrapper addBindingWrapper,
                                    ImplementByInterfaceHelper implementByInterfaceHelper)
        {
            _addBindingWrapper = addBindingWrapper;

            _implementByInterfaceHelper = implementByInterfaceHelper;
        }
        /// <summary>
        /// Bind type
        /// </summary>
        /// <param name="bindingTypes"></param>
        internal void Bind(TypesBinder bindingTypes)
        {
            if (bindingTypes.ImplementType != null)
            {
                _addBindingWrapper.Add(
                    bindingTypes.Services,
                    bindingTypes.SingleType,
                    bindingTypes.ImplementType,
                    bindingTypes.LifeTimeOptions,
                    bindingTypes.IsPropertiesAutoWired);
            }
            else if (bindingTypes.IsImplementByInterface)
            {
                _implementByInterfaceHelper.Add(
                    bindingTypes.Services,
                    bindingTypes.SingleType,
                    bindingTypes.LifeTimeOptions,
                    bindingTypes.IsPropertiesAutoWired);
            }
            else
            {
                _addBindingWrapper.Add(
                    bindingTypes.Services,
                    bindingTypes.SingleType,
                    null,
                    bindingTypes.LifeTimeOptions,
                    bindingTypes.IsPropertiesAutoWired);
            }
        }
    }
}
