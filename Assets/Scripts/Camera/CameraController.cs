using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float m_time = 0f;

    private void Update()
    {
        m_time += Time.deltaTime;
        CheckFlipCondition();
    }

    private void CheckFlipCondition()
    {
        if (m_time >= 15f)
        {
            InvertJump();
            m_time = 0f;
        }
    }

    private void InvertJump()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -transform.position.z);
        transform.rotation *= Quaternion.Euler(0f, 180f, 180f);
    }
}
