using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class TestingInputSystem : MonoBehaviour
{
    //Since the tutorial uses the same name with different case, please make sure to check the capital letters and don't be stupid like me.
    private Rigidbody sphereRigidBody;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;
    // Use different names if possible to avoid confusion for both you and the machine.

    private void Awake()
    {
        sphereRigidBody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        playerInputActions =  new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        float speed = 3f;
        sphereRigidBody.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if (context.performed)
        {
            Debug.Log("Jump! " + context.phase);
            sphereRigidBody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }

}
