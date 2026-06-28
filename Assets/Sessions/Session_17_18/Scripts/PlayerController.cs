using UnityEditor;
using UnityEngine;

[RequireComponent ( typeof ( Rigidbody2D ) )]
public class PlayerController : MonoBehaviour
{
    [Header ( "Movement" )]
    public float moveSpeed = 8f;
    private float horizontalInput;
    [SerializeField] SpriteRenderer spriteRenderer;

    //[Header ( "Jumping" )]
    public float jumpForce = 16f;
    public float jumpCutMultiplier = 0.5f; // For variable jump height
    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;

    void Start ( )
    {
        rb = GetComponent<Rigidbody2D> ( );
        Debug.Log ( "Got Rigidbody" );
    }

    void Update ( )
    {
        // Get input
        horizontalInput = Input.GetAxis( "Horizontal" );

        // Check if grounded
        isGrounded = Physics2D.OverlapCircle ( groundCheck.position, groundCheckRadius, groundLayer );

        // Jump
        if ( Input.GetButtonDown ( "Jump" ) && isGrounded )
        {
            rb.linearVelocity = new Vector2 ( rb.linearVelocity.x, jumpForce );
        }

        // Variable jump height (letting go of jump button early)
        if ( Input.GetButtonUp ( "Jump" ) && rb.linearVelocity.y > 0 )
        {
            rb.linearVelocity = new Vector2 ( rb.linearVelocity.x, rb.linearVelocity.y * jumpCutMultiplier );
        }

        //// Flip sprite based on direction
        spriteRenderer.flipX = horizontalInput >= 0 ? false : true;
    }

    void FixedUpdate ( )
    {
        // Apply horizontal movement
        rb.linearVelocity = new Vector2 ( horizontalInput * moveSpeed, rb.linearVelocity.y );
    }

    private void OnDrawGizmos ( )
    {
        Gizmos.DrawSphere ( groundCheck.position, groundCheckRadius );
    }
}
