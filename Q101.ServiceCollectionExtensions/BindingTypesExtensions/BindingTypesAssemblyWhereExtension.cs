using System;
using System.Linq;

namespace Q101.ServiceCollectionExtensions.BindingTypesExtensions
{
    /// <summary>
    /// Extension for BindingTypes type for filter types of assembly
    /// </summary>
    public static class BindingTypesAssemblyWhereExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bindingTypes"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static BindingTypes Where(this BindingTypes bindingTypes, Func<Type, bool> func)
        {
            if(bindingTypes.Assembly != null 
               || bindingTypes.Types != null && bindingTypes.Types.Any())
            {
                bindingTypes.Types = 
                    bindingTypes.Assembly != null
                     && (bindingTypes.Types == null
                            || !bindingTypes.Types.Any())
                        ? bindingTypes
                            .Assembly
                            .GetTypes()
                            .Where(func)
                            .ToArray()
                     : bindingTypes.Types
                            .Where(func)
                            .ToArray();
            }

            return bindingTypes;
        }
    }
}
