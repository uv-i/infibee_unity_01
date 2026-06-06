using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;


/*
 *  CYCLE - Class
 *  
 *  Color - Variable
 *  Wheel - Variable
 *  Stand - Variable
 *  
 *  Pedal () - Method
 *  
 *  Whenver the Pedal Method is the wheel will rotate and the value of the variable will change.
 *      This wheel rotation is moving the cycle forward if the stand is up and the cycle will stop if the stand is down.
 */

public class Variables : MonoBehaviour
{
    public char title = 'k';
    string colorString = "Red 1";
    Color color = Color.red;
    int wheel = 2;
    float speed =1.5f;
    bool isStanding = true;
}
