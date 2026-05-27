using UnityEngine;

public class FallState : PlayerState
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public FallState(PlayerStateMachine.EPlayerState key, PlayerController controller) : base(key, controller)
    {
    }

    private Vector3 _moveDirection;
    private float downforce = 0;

    public override void EnterState()
    {
        base.EnterState();
        downforce = 0;
    }

    public override void UpdateState()
    {
        
        
        
    }

    public override void FixedUpdateState()
    {
        var cam = player.LookDirection();
        _moveDirection = cam.forward * InputHandler.MoveInput().z + cam.right * InputHandler.MoveInput().x;
        player.Move(_moveDirection);
        player.RotateWithMovement(_moveDirection);
        
        downforce += Time.fixedDeltaTime * 3f;
        player.AddForce(Vector3.down, downforce);
        
    }

    public override PlayerStateMachine.EPlayerState GetNextState()
    {
        Debug.Log(player.IsGrounded());
        if (player.IsGrounded())
            return PlayerStateMachine.EPlayerState.Idle;
        
        return StateKey;
    }
}
