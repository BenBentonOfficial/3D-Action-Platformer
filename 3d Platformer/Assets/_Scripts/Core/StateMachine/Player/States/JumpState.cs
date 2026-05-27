using UnityEngine;

public class JumpState : PlayerState
{
    public JumpState(PlayerStateMachine.EPlayerState key, PlayerController controller) : base(key, controller)
    {
    }
    
    Vector3 _moveDirection;
    private float downforce = 0;

    public override void EnterState()
    {
        base.EnterState();
        downforce = 0;
        player.Jump();
    }

    public override void FixedUpdateState()
    {
        var cam = player.LookDirection();
        _moveDirection = cam.forward * InputHandler.MoveInput().z + cam.right * InputHandler.MoveInput().x;
        player.Move(_moveDirection);
        player.RotateWithMovement(_moveDirection);
        
        downforce += Time.fixedDeltaTime * 5f;
        player.AddForce(Vector3.down, downforce);
    }

    public override PlayerStateMachine.EPlayerState GetNextState()
    {
        if (player.IsGrounded())
            return PlayerStateMachine.EPlayerState.Idle;
        if (player.yVelocity <= 0)
            return PlayerStateMachine.EPlayerState.Fall;
        
        return StateKey;
    }
}
