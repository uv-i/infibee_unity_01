using UnityEngine;

public class CrowController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rgbd2d;
    [SerializeField] float tapStrength = 10.0f;

    private void Update ( )
    {
        if ( Input.GetMouseButtonDown ( 0 ) )
            OnTap ( );
    }

    void OnTap ( )
    {
        rgbd2d.AddForce ( Vector2.up * tapStrength, ForceMode2D.Impulse );
    }
}
