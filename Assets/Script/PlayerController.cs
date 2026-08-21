using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
        Debug.Log(inputVector);
    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValueAsButton());
    }

}
