using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gabevlogd.Patterns;

public class ObstaclesFactory : Factory<Obstacle, Enumerators.ObstaclesType>
{
    private List<Obstacle> m_obstaclesPrefabs;
    private ObstaclesPool m_obstaclesPool;
    private Transform m_obstaclesParent;

    public ObstaclesFactory(List<Obstacle> obstaclesPrefabs, ObstaclesPool obstaclesPool, Transform obstaclesParent)
    {
        m_obstaclesPrefabs = obstaclesPrefabs;
        m_obstaclesPool = obstaclesPool;
        m_obstaclesParent = obstaclesParent;
    }

    public override Obstacle CreateObject(Enumerators.ObstaclesType objectType)
    {
        Obstacle newObstacle;

        switch (objectType)
        {
            case Enumerators.ObstaclesType.Cactus:
                newObstacle = Object.Instantiate(m_obstaclesPrefabs[0], m_obstaclesParent);
                break;
            default:
                newObstacle = Object.Instantiate(m_obstaclesPrefabs[0], m_obstaclesParent);
                break;

        }

        newObstacle.InitObstacle(m_obstaclesPool);
        return newObstacle;
    }

    public Obstacle CreateRandomObject()
    {
        Enumerators.ObstaclesType randomObstacle = (Enumerators.ObstaclesType)Random.Range(0, m_obstaclesPrefabs.Count);
        return CreateObject(randomObstacle);
    }
}
