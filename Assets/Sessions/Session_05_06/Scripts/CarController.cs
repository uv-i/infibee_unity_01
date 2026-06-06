using UnityEngine;

/*
 * vector - direction + value(float);
 * 
 * Vector2 :- x : 0.0, y : 0.0 ;
 * Vector3 :- x : 0.0, y : 0.0, z : 0.0 ;
 * Vector4 :- u : 0.0, v : 0.0, w : 0.0, a : 0.0 ;  
 * 
 * 
 * Gravity Vector :- x:0.0 ,   y : 9.8 , z : 0.0;
 */

public class CarController : MonoBehaviour
{
    public Car car;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown ( KeyCode.F ) )
            MoveCar ( );
    }

    void MoveCar ( )
    {
        car.transform.position += Vector3.forward * 10;
        Debug.Log ( "Car moving Forward" );
    }
}
