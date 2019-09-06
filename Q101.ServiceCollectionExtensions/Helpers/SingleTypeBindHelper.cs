using Microsoft.Extensions.DependencyInjection;

namespace Q101.ServiceCollectionExtensions.Helpers
{
    /// <summary>
    /// Helper for bind single type(types)
    /// </summary>
    internal class SingleTypeBindHelper
    {
        /// <summary>
        /// Bind type
        /// </summary>
        /// <param name="bindingTypes"></param>
        internal static void Bind(BindingTypes bindingTypes)
        {
            if (bindingTypes.ImplementType != null)
            {
                AddBindingWrapper.Add(
                    bindingTypes.Services,
                    bindingTypes.SingleType,
                    bindingTypes.ImplementType,
                    bindingTypes.LifeTimeOptions,
                    bindingTypes.IsPropertiesAutoWired);
            }
            else if (bindingTypes.IsImplementByInterface)
            {
                ImplementByInterfaceHelper.Add(
                    bindingTypes.Services,
                    bindingTypes.SingleType,
                    bindingTypes.LifeTimeOptions,
                    bindingTypes.IsPropertiesAutoWired);
            }
            else
            {
                AddBindingWrapper.Add(
                    bindingTypes.Services,
                    bindingTypes.SingleType,
                    null,
                    bindingTypes.LifeTimeOptions,
                    bindingTypes.IsPropertiesAutoWired);
            }
        }
    }
}
