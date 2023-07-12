using Gabevlogd.Patterns;
using UnityEngine;

public class Run : PlayerState
{
    public Run(Enumerators.PlayerState stateID, StatesManager<Enumerators.PlayerState> stateManager = null) : base(stateID, stateManager)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        m_playerTransform.position = Vector3.zero;
        Debug.Log(m_playerTransform.position);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        HandleInput();
    }

    public override void HandleInput()
    {
        base.HandleInput();
        if (m_playerInput.DINOInput.Jump.WasPerformedThisFrame())
            m_playerStateMachine.ChangeState(Enumerators.PlayerState.Jump);
    }
}
