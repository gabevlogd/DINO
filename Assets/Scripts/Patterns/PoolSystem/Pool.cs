using System.Collections.Generic;

namespace Gabevlogd.Patterns
{
    /// <summary>
    /// This class represent a pool of generic objects
    /// </summary>
    /// <typeparam name="TPooledObjectType">Type of the objects in the pool</typeparam>
    public class Pool<TPooledObjectType> where TPooledObjectType : new()
    {
        protected List<TPooledObjectType> m_availables;
        protected List<TPooledObjectType> m_inUse;

        public Pool(int startSize, List<TPooledObjectType> availables = null)
        {
            m_inUse = new();

            if (availables == null)
            {
                m_availables = new();
                for (int i = 0; i < startSize; i++)
                {
                    TPooledObjectType pooledObject = new();
                    m_availables.Add(pooledObject);
                }
            }
            else m_availables = availables;
        }


        /// <summary>
        /// Returns an object from the pool (crates a new one if no availables objects left)
        /// </summary>
        public TPooledObjectType GetObject()
        {
            lock (m_availables)
            {
                if (m_availables.Count > 0)
                {
                    TPooledObjectType objectToReturn = m_availables[m_availables.Count - 1];
                    m_availables.Remove(objectToReturn);
                    m_inUse.Add(objectToReturn);

                    return objectToReturn;
                }
                else
                {
                    TPooledObjectType newObjectToReturn = new();
                    m_inUse.Add(newObjectToReturn);

                    return newObjectToReturn;
                }
            }
        }


        /// <summary>
        /// Puts an object back in the pool
        /// </summary>
        public void ReleaseObject(TPooledObjectType objectToRelease)
        {
            lock (m_availables)
            {
                m_inUse.Remove(objectToRelease);
                m_availables.Add(objectToRelease);
            }
        }


    }
}

