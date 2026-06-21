using UnityEngine;

public class OOPCarDemo : MonoBehaviour
{
    void Start ( )
    {
        Debug.Log ( "=== ⏱️ STARTING 10-MIN OOP CAR TOUR === " );

        // 1. Encapsulation Demo
        Debug.Log ( "--- 1. ENCAPSULATION ---" );
        CarEncapsulation mySedan = new CarEncapsulation ( "Civic" );
        mySedan.Accelerate ( 50f );
        // mySedan.currentSpeed = 500; // ❌ ERROR! Caught by encapsulation protection.

        // 2. Inheritance Demo
        Debug.Log ( "--- 2. INHERITANCE ---" );
        SportsCar myFerrari = new SportsCar ( );
        myFerrari.brand = "Ferrari"; // Inherited variable
        myFerrari.Honk ( );            // Inherited method
        myFerrari.UseNitro ( );        // Unique child method

        // 3. Polymorphism Demo
        Debug.Log ( "--- 3. POLYMORPHISM ---" );
        // We can treat different cars as the same base "Engine" type
        Engine genericEngine = new Engine ( );
        Engine teslaEngine = new ElectricCar ( );
        Engine mustangEngine = new RaceCar ( );

        genericEngine.StartEngine ( );
        teslaEngine.StartEngine ( );   // Behaves differently!
        mustangEngine.StartEngine ( ); // Behaves differently!

        // 4. Abstraction Demo
        Debug.Log ( "--- 4. ABSTRACTION ---" );
        // BaseCarBlueprint abstractCar = new BaseCarBlueprint(); // ❌ ERROR! Can't instantiate an abstract blueprint.
        BaseCarBlueprint traditionalCar = new GasCar ( );
        traditionalCar.FuelUp ( );
    }
}