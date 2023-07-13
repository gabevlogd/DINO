using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
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

    private void OnTriggerEnter(Collider other) => GameManager.EventManager.TriggerEvent(Enumerators.Event.ResetMatch);
}

[System.Serializable]
public struct PlayerData
{
    [HideInInspector]
    public Transform Transform;
    public PlayerInput Input;
    public PlayerStateMachine PlayerStateMachine;
    public MeshRenderer MeshRenderer;
}
