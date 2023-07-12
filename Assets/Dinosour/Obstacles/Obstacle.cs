using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DINO
{

    [RequireComponent(typeof(Rigidbody))]
    public class Obstacle : MonoBehaviour
    {
        public float Speed;
        public Transform SpawnPoint;
        protected Rigidbody m_rigidbody;

        protected virtual void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody>();
            m_rigidbody.velocity = new Vector3(-Speed, 0f, 0f);
            transform.position = SpawnPoint.position;
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
}
