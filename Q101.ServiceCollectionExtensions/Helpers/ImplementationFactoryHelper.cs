using System;

namespace Q101.ServiceCollectionExtensions.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    internal class ImplementationFactoryHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        internal object PropsAutoWired(IServiceProvider provider, Type type)
        {
            var obj = Activator.CreateInstance(type);

            var props = type.GetProperties();

            foreach (var propertyInfo in props)
            {
                propertyInfo.SetValue(obj,
                    provider.GetService(propertyInfo.PropertyType));
            }

            return obj;
        }
    }
}
