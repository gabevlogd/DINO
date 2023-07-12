using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public float MinSpawnDeltaTime;
    public float MaxSpawnDeltaTime;

    private float m_timer;
    private float m_randomDeltaTime;

    private void Awake() => SetNewSpawnCondition();

    private void Update() => CheckSpwanRequest();

    private void CheckSpwanRequest()
    {
        if (m_timer >= m_randomDeltaTime) Spawn();
        m_timer += Time.deltaTime;
    }

    private void Spawn()
    {
        Instantiate(ObjectToSpawn);
        SetNewSpawnCondition();
    }

    private void SetNewSpawnCondition()
    {
        m_randomDeltaTime = Random.Range(MinSpawnDeltaTime, MaxSpawnDeltaTime);
        m_timer = 0f;
    }
}
