using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Obstacle> ObstaclePrefabs;
    public float MinSpawnDeltaTime;
    public float MaxSpawnDeltaTime;

    private ObstaclesPool m_obstaclesPool;
    private float m_timer;
    private float m_randomDeltaTime;

    private void Awake()
    {
        m_obstaclesPool = new ObstaclesPool(0, ObstaclePrefabs, transform);
        ResetSpawnCondition();

        GameManager.EventManager.Register(Enumerators.Event.ResetMatch, ResetPool);
    }

    private void Update() => CheckSpwanRequest();

    private void CheckSpwanRequest()
    {
        if (m_timer >= m_randomDeltaTime) Spawn();
        m_timer += Time.deltaTime;
    }

    private void Spawn()
    {
        Obstacle spawnedObstacle = m_obstaclesPool.GetObject();
        spawnedObstacle.EnableObstacle();
        ResetSpawnCondition();
    }

    private void ResetSpawnCondition()
    {
        m_randomDeltaTime = Random.Range(MinSpawnDeltaTime, MaxSpawnDeltaTime);
        m_timer = 0f;
    }

    public void ResetPool()
    {
        m_obstaclesPool = m_obstaclesPool = new ObstaclesPool(0, ObstaclePrefabs, transform);
        foreach (Transform child in transform) Destroy(child.gameObject);
        
    }

    private Vector3 GetSpawnPosition() //to continue;
    {
        float targetDepth = Vector3.Distance(GameManager.Instance.Player.transform.position, transform.position);
        Vector3 screenPoint = new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight * 0.5f, targetDepth); //screen spawn point
        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(screenPoint); // world spawn pointeo
                                                                             //spawnPosition += new Vector3(0f, PositionY, 0f); // set the y position
        return spawnPosition;
    }
}
