public class IdleState : PlayerState
{
    public IdleState(PlayerStateMachine.EPlayerState key, PlayerController controller) : base(key, controller)
    {
    }

    public override void EnterState()
    {
        player.ZeroVelocity();
    }

    public override PlayerStateMachine.EPlayerState GetNextState()
    {
        if (InputHandler.MoveInput().magnitude > 0)
            return PlayerStateMachine.EPlayerState.Move;
        if(InputHandler.instance.TryJump.Queued)
            return PlayerStateMachine.EPlayerState.Jump;

        return StateKey;
    }
}
