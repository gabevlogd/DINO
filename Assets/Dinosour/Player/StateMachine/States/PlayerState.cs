using Gabevlogd.Patterns;
using UnityEngine;

namespace DINO
{
    public class PlayerState : State<Enumerators.PlayerState>
    {
        protected PlayerStateMachine m_playerStateMachine;
        protected PlayerInput m_playerInput;
        protected Transform m_playerTransform;

        public PlayerState(Enumerators.PlayerState stateID, StatesManager<Enumerators.PlayerState> stateManager = null) : base(stateID, stateManager)
        {
            m_playerStateMachine = m_stateManager as PlayerStateMachine;
            m_playerTransform = m_playerStateMachine.PlayerData.Transform;
            m_playerInput = m_playerStateMachine.PlayerData.Input;
            //Debug.Log(stateID);
        }

        public virtual void HandleInput()
        {
            //Debug.Log("HandleInput");
        }
    }
}
