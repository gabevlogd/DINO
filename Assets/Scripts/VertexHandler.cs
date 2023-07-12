using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VertexHandler : MonoBehaviour
{
    public int Width, Height;
    public float CellSize;
    public float Speed;
    public float ChangeDirectionSpeed;
    public GameObject VertexPrefab;
    [Range(-1, 1)]
    public int test;

    private Grid<VertexData> m_grid;
    private int m_direction;

    public void Awake()
    {
        m_grid = new Grid<VertexData>(Width, Height, CellSize, Vector3.zero, (int x, int y) => new VertexData(x, y));
        GeneratePlane(); 
    }

    private void Update()
    {
        MoveVertex();
        Debug.Log(GetDirection());
    }

    private void GeneratePlane()
    {
        for(int y = 0; y < m_grid.GetHeight(); y++)
        {
            for(int x = 0; x < m_grid.GetWidth(); x++)
            {
                GameObject vertex = Instantiate(VertexPrefab, m_grid.GetWorldPosition(x, y), Quaternion.identity);
                Debug.Log(Mathf.PerlinNoise(x, y) * Speed);
                m_grid.GetGridObject(x, y).WorldVertex = vertex;
                //vertex.transform.position += new Vector3(0f, (Mathf.PerlinNoise(vertex.transform.position.x, vertex.transform.position.z) * noise) + test, 0f);
            }
        }
    }

    private void MoveVertex()
    {
        for (int y = 0; y < m_grid.GetHeight(); y++)
        {
            for (int x = 0; x < m_grid.GetWidth(); x++)
            {
                Transform vertex = m_grid.GetGridObject(x, y).WorldVertex.transform;
                //vertex.position += new Vector3(0f, GetDirection() * Mathf.PerlinNoise(vertex.transform.position.x /** Time.deltaTime * ChangeDirectionSpeed*/, vertex.transform.position.z /** Time.deltaTime * ChangeDirectionSpeed*/) * noise * Time.deltaTime, 0f);
                vertex.position += new Vector3(0f, GetDirection() * Speed * Time.deltaTime, 0f);
            }
        }
    }

    private int GetDirection()
    {
        if (Mathf.Sin(Time.time * ChangeDirectionSpeed) < 0f) return -1;
        else return 1;
    }
}
