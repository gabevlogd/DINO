using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gabevlogd.Patterns;

public class ObstaclesFactory : Factory<Obstacle, Enumerators.ObstaclesType>
{
    private List<Obstacle> m_obstaclesPrefabs;
    private ObstaclesPool m_obstaclesPool;

    public ObstaclesFactory(List<Obstacle> obstaclesPrefabs, ObstaclesPool obstaclesPool)
    {
        m_obstaclesPrefabs = obstaclesPrefabs;
        m_obstaclesPool = obstaclesPool;
    }

    public override Obstacle CreateObject(Enumerators.ObstaclesType objectType)
    {
        Obstacle newObstacle;

        switch (objectType)
        {
            case Enumerators.ObstaclesType.Cactus:
                newObstacle = Object.Instantiate(m_obstaclesPrefabs[0]);
                break;
            default:
                newObstacle = Object.Instantiate(m_obstaclesPrefabs[0]);
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
