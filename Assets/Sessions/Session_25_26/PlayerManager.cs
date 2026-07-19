using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent ( typeof ( Rigidbody ) )]
public class PlayerManager : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Vector2 moveInput;
    [SerializeField] Animator animator;

    public Vector2 movement => moveInput;

    private void Update ( )
    {
        if( //Input.GetKey(KeyCode.W) || 
            Keyboard.current.wKey.isPressed)
        {
            moveInput.y = 1;
        }
        else if ( //Input.GetKey ( KeyCode.S ) || 
            Keyboard.current.sKey.isPressed)
        {
            moveInput.y = -1;
        }
        else
        {
            moveInput.y = 0;
        }

        if ( //Input.GetKey ( KeyCode.A ) || 
            Keyboard.current.aKey.isPressed)
        {
            moveInput.x = -1;
        }
        else if ( //Input.GetKey ( KeyCode.D ) || 
            Keyboard.current.dKey.isPressed)
        {
            moveInput.x = 1;
        }
        else
        {
            moveInput.x = 0;
        }

        animator.SetBool("IsIdle", moveInput.magnitude == 0.0f );
    }

    private void FixedUpdate ( )
    {
        rb.linearVelocity = new Vector3 ( moveInput.x, rb.linearVelocity.y, moveInput.y );
    }

    public void PlayFootStep()
    {
        SFXController.instance.PlaySfx ( );
    }
}
