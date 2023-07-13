namespace Gabevlogd.Patterns
{
    /// <summary>
    /// Factory method pattern template 
    /// </summary>
    /// <typeparam name="TFactoryObject">The return of CreateObject abstract method</typeparam>
    /// <typeparam name="TObjectType">The parameter of CreateObject abstract method</typeparam>
    public abstract class Factory<TFactoryObject, TObjectType>
    {
        /// <summary>
        /// Creates object of tipe TFactoryObject based on the TObjectType passed
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public abstract TFactoryObject CreateObject(TObjectType objectType);
    }
}

