using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cube : MonoBehaviour, ISelectable/*, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler*/
{
    private delegate void Action<in T>(T obj);
    private Action<float> m_moveSelectable;
    private float m_targetDepth;

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    PickObject();
    //}

    //public void OnPointerMove(PointerEventData eventData)
    //{
    //    m_moveSelectable?.Invoke();

    //}

    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    ReleaseObject();
    //}

    private void OnMouseDown()
    {
        PickObject();
    }

    private void OnMouseDrag()
    {
        //Debug.Log("OnMouseDrag");
        MoveObject(m_targetDepth);
    }

    

    public void PickObject()
    {
        //Debug.Log("PickObject");
        m_targetDepth = Vector3.Distance(Player.playerTransform.position, transform.position);
        //m_moveSelectable = MoveObject;

    }

    public void MoveObject(float targetDepth)
    {
        //Debug.Log("MoveObject");
        m_targetDepth += Input.mouseScrollDelta.y;
        m_targetDepth = Mathf.Clamp(m_targetDepth + Input.mouseScrollDelta.y, 1f, 10f);
        Vector3 worldPosition = new Vector3(Camera.main.pixelWidth * 0.5f, Camera.main.pixelHeight * 0.5f, targetDepth);
        transform.position = Camera.main.ScreenToWorldPoint(worldPosition);
    }

    public void ReleaseObject()
    {
        //Debug.Log("ReleaseObject");
        //m_moveSelectable = null;
        
    }

    
}
