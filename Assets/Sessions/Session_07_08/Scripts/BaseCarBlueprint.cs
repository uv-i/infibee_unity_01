using UnityEngine;

// Abstract class cannot be instantiated directly with 'new'
public abstract class BaseCarBlueprint
{
    // Abstract method has no body; children MUST implement their own version
    public abstract void FuelUp ( );
}

public class GasCar : BaseCarBlueprint
{
    public override void FuelUp ( )
    {
        Debug.Log ( "Filling up the tank with Premium Gasoline at the pump." );
    }
}