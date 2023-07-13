using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gabevlogd.Patterns;

public class ObstaclesPool 
{
    protected List<Obstacle> m_availables;
    protected List<Obstacle> m_inUse;
    protected ObstaclesFactory m_obstaclesFactory;

    public ObstaclesPool(int startSize, List<Obstacle> obstaclesPrefabs)
    {
        m_obstaclesFactory = new(obstaclesPrefabs, this);
        m_inUse = new();
        m_availables = new();

        for (int i = 0; i < startSize; i++)
        {
            Obstacle pooledObject = m_obstaclesFactory.CreateRandomObject();
            m_availables.Add(pooledObject);
        }
    }


    /// <summary>
    /// Returns an object from the pool (crates a new one if no availables objects left)
    /// </summary>
    public Obstacle GetObject()
    {
        lock (m_availables)
        {
            if (m_availables.Count > 0)
            {
                Obstacle objectToReturn = m_availables[m_availables.Count - 1];
                m_availables.Remove(objectToReturn);
                m_inUse.Add(objectToReturn);

                return objectToReturn;
            }
            else
            {
                Obstacle newObjectToReturn = m_obstaclesFactory.CreateRandomObject();
                m_inUse.Add(newObjectToReturn);

                return newObjectToReturn;
            }
        }
    }


    /// <summary>
    /// Puts an object back in the pool
    /// </summary>
    public void ReleaseObject(Obstacle objectToRelease)
    {
        lock (m_availables)
        {
            m_inUse.Remove(objectToRelease);
            m_availables.Add(objectToRelease);
        }
    }
}
