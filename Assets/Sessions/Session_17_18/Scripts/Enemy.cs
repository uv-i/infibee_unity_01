using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float bounceForce = 10f; // Force applied to player when they stomp the enemy
    private int direction = 1; // -1 for left, 1 for right

    public Transform wallCheck;
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    private Collider2D col;

    void Start ( )
    {
        rb = GetComponent<Rigidbody2D> ( );
        col = GetComponent<Collider2D> ( );
    }

    void FixedUpdate ( )
    {
        // Move the enemy
        rb.linearVelocity = new Vector2 ( direction * moveSpeed, rb.linearVelocity.y );

        // Check if hitting a wall to turn around
        bool hittingWall = Physics2D.OverlapCircle ( wallCheck.position, 0.1f, groundLayer );
        if ( hittingWall )
        {
            Flip ( );
        }
    }

    void Flip ( )
    {
        direction *= -1;
        transform.localScale = new Vector3 ( transform.localScale.x * -1, transform.localScale.y, transform.localScale.z );
    }

    void OnCollisionEnter2D ( Collision2D collision )
    {
        Debug.Log ( "Collision Detected" );
        if ( collision.gameObject.CompareTag ( "Player" ) )
        {
            Debug.Log ( "Colliding with Player" );
            // Calculate if the player hit the enemy from above
            Collider2D playerCol = collision.collider;
            bool hitFromAbove = playerCol.bounds.min.y > col.bounds.max.y - 0.2f;

            if ( hitFromAbove )
            {
                // Defeat enemy and bounce player
                Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D> ( );
                if ( playerRb != null )
                {
                    playerRb.linearVelocity = new Vector2 ( playerRb.linearVelocity.x, bounceForce );
                }
                Destroy ( gameObject );
                //}
                //else
                //{
                //    // Player takes damage (You would call a Player Health script here)
                //    Debug.Log ( "Player took damage!" );
            }
        }
    }

    private void OnDrawGizmos ( )
    {
        Gizmos.DrawSphere ( wallCheck.position, 0.1f );
    }
}