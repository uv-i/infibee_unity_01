using UnityEngine;

// The Base (Parent) Class
public abstract class Vehicle
{
    public string brand = "Generic Brand";

    public abstract void Honk ( ) ;
}

// The Derived (Child) Class inherits everything from Vehicle
public class SportsCar : Vehicle
{
    public bool turboCharged = true;

    public override void Honk ( )
    {
        Debug.Log ( " KEENG !!!" );
    }

    public void UseNitro ( )
    {
        Debug.Log ( $"{brand} Sports Car activated Nitro Boost!" );
    }

    public class SUV  : Vehicle
    {
        public bool allWheelDrive = true;
        public void OffRoad ( )
        {
            Debug.Log ( $"{brand} SUV is going off-road!" );
        }

        public override void Honk ( )
        {
            Debug.Log( "Beep Beep!" );
        }
    }
}