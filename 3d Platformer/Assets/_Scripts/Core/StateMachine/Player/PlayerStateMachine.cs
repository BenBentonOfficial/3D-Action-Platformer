using UnityEngine;

public class PlayerStateMachine : StateMachine<PlayerStateMachine.EPlayerState>
{
    public enum EPlayerState
    {
        Idle, 
        Move,
        Jump,
        Fall
    }

    public void Initialize(PlayerController player)
    {
        States.Add(EPlayerState.Idle, new IdleState(EPlayerState.Idle, player));
        States.Add(EPlayerState.Move, new MoveState(EPlayerState.Move, player));
        States.Add(EPlayerState.Jump, new JumpState(EPlayerState.Jump, player));
        States.Add(EPlayerState.Fall, new FallState(EPlayerState.Fall, player));
        

        CurrentState = States[EPlayerState.Idle];
    }
}