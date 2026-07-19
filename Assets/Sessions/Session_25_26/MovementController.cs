using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Vector2 moveInput;
    //[SerializeField] PlayerInput playerInput;

    public Vector2 movement => moveInput;

    public void OnJump ( InputAction.CallbackContext cntxt )
    {
        if(cntxt.performed) rb.AddForce(Vector3.up * 100f, ForceMode.Impulse );
    }

    public void OnMove ( InputAction.CallbackContext cntxt )
    {
        Debug.Log( "Value: " + cntxt.ReadValue<Vector2> ( ) );
        moveInput = cntxt.ReadValue<Vector2>();
    }

    void Update()
    {
        rb.linearVelocity = new Vector3 ( moveInput.x, rb.linearVelocity.y, moveInput.y );
    }
}
