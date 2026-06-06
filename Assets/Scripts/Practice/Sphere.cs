using UnityEngine;

public class Sphere : MonoBehaviour
{
    public float minLaunchForce = -10f;
    public float maxLaunchForce = 10f;
    public Rigidbody _rigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float randomX = Random.Range(minLaunchForce, maxLaunchForce);
        float randomY = Random.Range(0f, maxLaunchForce);
        float randomZ = Random.Range(minLaunchForce, maxLaunchForce);

        Vector3 randomVelocity = new Vector3(randomX, randomY, randomZ);

        _rigidbody.AddForce(randomVelocity, ForceMode.Impulse);
    }

}
