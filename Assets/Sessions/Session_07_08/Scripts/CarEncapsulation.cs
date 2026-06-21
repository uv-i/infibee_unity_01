using UnityEngine;

public class CarEncapsulation
{
    // Private variables - hidden from the outside world
    private string modelName;
    private float currentSpeed;
    private float maxSpeed = 120f;

    // Constructor
    public CarEncapsulation ( string model )
    {
        modelName = model;
    }

    // Public method - the "interface" the user interacts with
    public void Accelerate ( float amount )
    {
        currentSpeed += amount;
        // Encapsulation allows us to add safety boundaries safely
        currentSpeed = Mathf.Clamp ( currentSpeed, 0, maxSpeed );

        Debug.Log ( $"{modelName} is accelerating. Current Speed: {currentSpeed} mph." );
    }
}