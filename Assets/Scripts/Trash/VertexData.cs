using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexData
{
    public int x, y;
    public GameObject WorldVertex;

    public VertexData(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override string ToString()
    {
        return "X: " + x + " Y: " + y;
    }
}
