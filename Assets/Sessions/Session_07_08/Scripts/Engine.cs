using UnityEngine;

// Parent Class
public class Engine
{
    public virtual void StartEngine ( )
    {
        Debug.Log ( "Engine starts with a generic rumble." );
    }
}

// Child Class 1
public class ElectricCar : Engine
{
    public override void StartEngine ( )
    {
        Debug.Log ( "Electric Car turns on... Dead silent. ⚡" );
    }
}

// Child Class 2
public class RaceCar : Engine
{
    public override void StartEngine ( )
    {
        Debug.Log ( "Race Car ROARS to life! VROOM! 🏎️" );
    }
}