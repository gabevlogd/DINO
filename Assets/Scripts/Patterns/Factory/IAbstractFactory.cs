namespace Gabevlogd.Patterns
{

    /// <summary>
    /// Abstract factory pattern
    /// </summary>
    public interface IAbstractFactory
    {
        /// <summary>
        /// Initializes all the IFactoryObject's parameters
        /// </summary>
        public abstract void InitObject();
        public abstract string GetName();
    }
}


    
