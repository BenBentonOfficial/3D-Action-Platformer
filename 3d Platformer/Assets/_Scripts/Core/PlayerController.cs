using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private Transform cam;
    private Animator anim;
    
    public Animator Animator => anim;
    
    private PlayerStateMachine stateMachine;

    [SerializeField] private float jumpForce;
    
    [SerializeField] private float groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        stateMachine = GetComponent<PlayerStateMachine>();
        anim = GetComponent<Animator>();
        
        stateMachine.Initialize(this);
        
        cam = Camera.main.transform;
    }
    
    public void RotateWithMovement(Vector3 dir)
    {
        if (dir.magnitude <= 0)
            return;
        
        Quaternion targetRotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10 * Time.fixedDeltaTime);
    }

    public (Vector3 forward, Vector3 right) LookDirection()
    {
        var camForward = cam.forward;
        var camRight = cam.right;
        
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();
        
        return (camForward, camRight);
    }
    
    public void ZeroVelocity() => rb.linearVelocity = Vector3.zero;
    
    public void Move(Vector3 dir)
    {
        rb.linearVelocity = new Vector3(dir.x * 5f, rb.linearVelocity.y, dir.z * 5f); //speed
    }

    public void AirMove(Vector3 dir)
    {
        rb.linearVelocity = new Vector3(dir.x * 2f, rb.linearVelocity.y, dir.z * 2f); // air speed
    }

    public void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z); // jumpForce
    }

    public void AddForce(Vector3 dir,  float force)
    {
        rb.AddForce(dir * force, ForceMode.VelocityChange);
    }
    
    public bool IsGrounded() => Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
    
    public float yVelocity => rb.linearVelocity.y;
}
