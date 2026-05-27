public class PlayerState : State<PlayerStateMachine.EPlayerState>
{

    public PlayerState(PlayerStateMachine.EPlayerState key, PlayerController controller) : base(key)
    {
        player = controller;
    }

    protected PlayerController player;
    

    public override void EnterState()
    {
        base.EnterState();
        //Anim.SetBool(StateKey.ToString(), true);
    }

    public override void UpdateState()
    {
        
    }

    public override void FixedUpdateState()
    {
        
    }

    public override void ExitState()
    {
        base.ExitState();
        //Anim.SetBool(StateKey.ToString(), false);
    }



    public override PlayerStateMachine.EPlayerState GetNextState()
    {
        throw new System.NotImplementedException();
    }
}