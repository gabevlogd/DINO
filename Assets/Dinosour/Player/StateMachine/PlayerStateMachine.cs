using UnityEngine;
using Gabevlogd.Patterns;
using System.Collections.Generic;

namespace DINO
{
    public class PlayerStateMachine : StatesManager<Enumerators.PlayerState>
    {
        public PlayerData PlayerData;
            
        public PlayerStateMachine(ref PlayerData playerData, Dictionary<Enumerators.PlayerState, State<Enumerators.PlayerState>> allStates = null, State<Enumerators.PlayerState> currentState = null, State<Enumerators.PlayerState> previousState = null) : base(allStates, currentState, previousState)
        {
            PlayerData = playerData;
            InitStatesManager();
        }

        protected override void InitStates()
        {
            AllStates.Add(Enumerators.PlayerState.Run, new Run(Enumerators.PlayerState.Run, this));
            AllStates.Add(Enumerators.PlayerState.Jump, new Jump(Enumerators.PlayerState.Jump, this));

            CurrentState = AllStates[Enumerators.PlayerState.Run];
            CurrentState.OnEnter();
        }
    }
}
