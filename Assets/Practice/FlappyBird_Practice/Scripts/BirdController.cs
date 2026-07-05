using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rgbd2d;
    [SerializeField] private float tapStrength = 8.0f;
    [SerializeField] private float diveStrength = 8.0f;

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.isGameOver) return;

        if (Input.GetMouseButtonDown(0)) OnTapUp();
        if (Input.GetMouseButtonDown(1)) OnTapDown();
    }

    void OnTapUp()
    {
        if (rgbd2d == null) return;
        rgbd2d.linearVelocity = Vector2.zero;
        rgbd2d.AddForce(Vector2.up * tapStrength, ForceMode2D.Impulse);
    }

    void OnTapDown()
    {
        if (rgbd2d == null) return;
        rgbd2d.linearVelocity = Vector2.zero;
        rgbd2d.AddForce(Vector2.down * diveStrength, ForceMode2D.Impulse);
    }

    // Unity automatically passes child collider events up to the parent script
    // if the parent holds the Rigidbody2D!
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pillar"))
        {
            Debug.LogWarning("💀 CRASH! Hit a solid pillar.");
            if (GameManager.Instance != null) GameManager.Instance.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ScoreTrigger"))
        {
            Debug.Log("🎯 Passed through the gap! Score +1.");
            if (GameManager.Instance != null) GameManager.Instance.IncreaseScore();
        }
    }
}