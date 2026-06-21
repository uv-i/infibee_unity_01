using UnityEngine;

namespace Shared {
    public class Cube : MonoBehaviour
    {
        public Material material;
        public Color red;
        public Color green;
        public Color blue;

        public Vector2 velocity;
        public Rigidbody _rigidbody;
        public ForceMode forceMode;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            //_rigidbody.linearVelocity = new Vector2(1.0f, 0.0f);
            if (Input.GetKeyDown(KeyCode.R))
                material.color = red;

            if (Input.GetKeyDown(KeyCode.G))
                material.color = green;

            if (Input.GetKeyDown(KeyCode.B))
                material.color = blue;

            if (Input.GetKeyDown(KeyCode.U))
            {
                _rigidbody.AddForce(velocity, forceMode);
                Debug.Log("U Clicked");
            }
        }
    }
}