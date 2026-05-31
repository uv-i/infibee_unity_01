using UnityEngine;

public class Cube : MonoBehaviour
{
    public Material material;
    public Color red;
    public Color green;
    public Color blue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
            material.color  = red;

        if ( Input.GetKeyDown ( KeyCode.G ) )
            material.color = green;

        if ( Input.GetKeyDown ( KeyCode.B ) )
            material.color = blue;
    }
}
