using System.Linq;
using Q101.ServiceCollectionExtensions.Helpers;

namespace Q101.ServiceCollectionExtensions.BindingTypesExtensions
{
    /// <summary>
    /// Bind types extension for bind action
    /// </summary>
    public static class BindingTypesBindActionExtension
    {
        /// <summary>
        /// Bind types by options
        /// </summary>
        /// <param name="bindingTypes"></param>
        public static void Bind(this BindingTypes bindingTypes)
        {
            if (bindingTypes.Assembly != null 
                || bindingTypes.Types != null && !bindingTypes.Types.Any())
            {
                if (bindingTypes.Types != null && !bindingTypes.Types.Any())
                {
                    TypeRangeBindHelper.Bind(bindingTypes);
                }
                else if(bindingTypes.Assembly != null)
                {
                    bindingTypes.Types = bindingTypes.Assembly.GetTypes();

                    TypeRangeBindHelper.Bind(bindingTypes);
                }
            }
            else if(bindingTypes.SingleType != null)
            {
                SingleTypeBindHelper.Bind(bindingTypes);
            }

        }
    }
}
