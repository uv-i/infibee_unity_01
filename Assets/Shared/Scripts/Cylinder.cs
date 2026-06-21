using UnityEngine;

public class Cylinder : MonoBehaviour
{
    public Vector3 velocity;
    public Rigidbody _rigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody.AddForce(velocity, ForceMode.Impulse);
    }
}
