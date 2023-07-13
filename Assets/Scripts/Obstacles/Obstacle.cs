using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Obstacle : MonoBehaviour, IObstacle
{
    public float Speed;
    public Transform SpawnPoint;
    protected Rigidbody m_rigidbody;
    protected ObstaclesPool m_obstaclesPool;
    protected MeshRenderer m_meshRenderer;

    

    public virtual void InitObstacle(ObstaclesPool obstaclesPool)
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_meshRenderer = GetComponentInChildren<MeshRenderer>();
        m_obstaclesPool = obstaclesPool;
        m_rigidbody.velocity = new Vector3(-Speed, 0f, 0f);
        DisableObstacle();
    }

    public virtual void DisableObstacle()
    {
        m_obstaclesPool.ReleaseObject(this);
        gameObject.SetActive(false);
    }

    public virtual void EnableObstacle()
    {
        transform.position = SpawnPoint.position;
        gameObject.SetActive(true);
        StartCoroutine(test());
    }

    private IEnumerator test()
    {
        yield return new WaitForSeconds(2f);

        yield return new WaitUntil(() => m_meshRenderer.isVisible == false);

        DisableObstacle();
    }


}


