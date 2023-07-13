using Gabevlogd.Patterns;
using UnityEngine;

public class Jump : PlayerState
{

    private Vector3 m_startVelocity;
    private float m_time;
    private float m_maxHeight = 2f;

    public Jump(Enumerators.PlayerState stateID, StatesManager<Enumerators.PlayerState> stateManager = null) : base(stateID, stateManager)
    {
        m_startVelocity = new Vector3(0f, Mathf.Sqrt(2f * -Physics.gravity.y * m_maxHeight), 0f);
    }

    public override void OnEnter()
    {
        base.OnEnter();
        m_time = 0;
        SetShaderDistortion(10f);
    }

    public override void OnFixedUpdate()
    {
        base.OnFixedUpdate();
        PerformJump();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        HandleInput();
    }

    public override void OnExit()
    {
        base.OnExit();
        SetShaderDistortion(0f);
    }

    public override void HandleInput()
    {
        base.HandleInput();
        if (m_playerTransform.position.y < 0f)
            m_playerStateMachine.ChangeState(Enumerators.PlayerState.Run);
    }

    private void PerformJump() => m_playerTransform.position = m_startVelocity * GetTime() + 0.5f * Physics.gravity * Mathf.Pow(GetTime(), 2f);

    private float GetTime() => m_time += Time.deltaTime;

    private void SetShaderDistortion(float value) => m_playerStateMachine.PlayerData.MeshRenderer.material.SetFloat("_Distortion", value);
}
