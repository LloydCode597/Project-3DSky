using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;
    private Vector2 moveInput;
    private bool jumpInput;
    private Rigidbody rig;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Physics code will go here.
        Vector3 velocity = new Vector3(moveInput.x, 0, moveInput.y) * moveSpeed;


        if (jumpInput && IsGrounded())
        {
            jumpInput = false;
            rig.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }

        jumpInput = false;
        velocity.y = rig.linearVelocity.y;

        rig.linearVelocity = velocity;

    }

    bool IsGrounded()
    {
        if (Physics.Raycast(transform.position + new Vector3(0, 0.1f, 0), Vector3.down, 0.2f))
        {
            return true;
        }

        return false;
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        jumpInput = context.ReadValueAsButton();
    }

}
