using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DINO
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        public PlayerData Data;

        private void Awake()
        {
            Data.Input = new PlayerInput();
            Data.Transform = transform;
            Data.PlayerStateMachine = new PlayerStateMachine(ref Data);
        }

        private void OnEnable() => Data.Input.Enable();

        private void OnDisable() => Data.Input.Disable();

        private void FixedUpdate() => Data.PlayerStateMachine.CurrentState.OnFixedUpdate();

        private void Update() => Data.PlayerStateMachine.CurrentState.OnUpdate();
    }

    [System.Serializable]
    public struct PlayerData
    {
        [HideInInspector]
        public Transform Transform;
        public PlayerInput Input;
        public PlayerStateMachine PlayerStateMachine;
    }
}
