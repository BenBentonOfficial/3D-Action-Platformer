using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public static InputHandler instance;

    [SerializeField] private InputActionReference Move;
    
    public GameAction TryJump;

    private float inputConsumeTimer;
    
    //public bool usingGamepad;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        instance = this;
        
        TryJump.Setup(this, 0.1f );
    }

    private void Update()
    {
        inputConsumeTimer -= Time.deltaTime;

        if (inputConsumeTimer <= 0)
        {
            TryJump.Consume();
        }
    }
    
    public void SetInputConsumeTimer(float time) => inputConsumeTimer = time;

    public static Vector3 MoveInput()
    {
        var move = instance.Move.action.ReadValue<Vector2>();
        var newMove = new Vector3(move.x, 0, move.y);
        return newMove;
    }
    
    /*private void OnControlsChanged(PlayerInput playerInput)
    {
        usingGamepad = playerInput.currentControlScheme.Equals("Gamepad");
    }*/
    
    
}