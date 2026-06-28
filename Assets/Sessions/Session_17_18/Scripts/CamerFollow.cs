using UnityEngine;

public class CamerFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothSpeed = 5f;
    [SerializeField] Vector3 offset = new Vector3 ( 0f, 2f, -10f );

    private void LateUpdate ( )
    {
        if ( target == null )
            return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime );
        transform.position = smoothedPosition;
    }
}
