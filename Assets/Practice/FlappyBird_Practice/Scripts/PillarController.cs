using UnityEngine;

public class PillarController : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float leftBoundary = -12.0f;

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.isGameOver) return;

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < leftBoundary)
        {
            Destroy(gameObject);
        }
    }
}