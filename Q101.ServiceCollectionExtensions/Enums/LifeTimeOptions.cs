namespace Q101.ServiceCollectionExtensions.Enums
{
    /// <summary>
    /// Life time option of services
    /// </summary>
    public enum LifeTimeOptions
    {
        /// <summary>
        /// every time you access the service, a new service object is created.
        /// During one request, there may be several calls to the service;
        /// accordingly, each call will create a new object.
        /// Such a life cycle model is best suited for lightweight services
        /// that do not store state data.
        /// </summary>
        Transient,

        /// <summary>
        /// for each request its own service object is created.
        /// That is, if during one request there are several calls
        /// to the same service, then all of these calls will use the same service object.
        /// </summary>
        Scoped,

        /// <summary>
        /// the service object is created the first time it is accessed,
        /// all subsequent requests use the same previously created service object
        /// </summary>
        Singleton
    }
}
