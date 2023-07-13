using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract obstacle factory
/// </summary>
public interface IObstacle 
{
    public void InitObstacle(ObstaclesPool obstaclesPool);

    public void EnableObstacle();
    public void DisableObstacle();
}
