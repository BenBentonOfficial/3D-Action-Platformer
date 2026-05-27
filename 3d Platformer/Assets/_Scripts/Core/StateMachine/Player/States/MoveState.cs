using UnityEngine;

public class MoveState : PlayerState
{
    public MoveState(PlayerStateMachine.EPlayerState key, PlayerController controller) : base(key, controller)
    {
    }
    
    Vector3 _moveDirection;
    public override void UpdateState()
    {
        base.UpdateState();
        
        
    }

    public override void FixedUpdateState()
    {
        var cam = player.LookDirection();
        _moveDirection = cam.forward * InputHandler.MoveInput().z + cam.right * InputHandler.MoveInput().x;
        player.Move(_moveDirection);
        
        player.RotateWithMovement(_moveDirection);
    }

    public override PlayerStateMachine.EPlayerState GetNextState()
    {
        if (InputHandler.MoveInput().magnitude <= 0)
            return PlayerStateMachine.EPlayerState.Idle;
        if (InputHandler.instance.TryJump.Queued)
            return PlayerStateMachine.EPlayerState.Jump;
        
        return StateKey;
    }
}
