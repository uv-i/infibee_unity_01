using UnityEngine;

public class PillarMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    private void Update ( )
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}
