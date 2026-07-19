using System.Collections;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioClip footStepClip;
    //[SerializeField] MovementController movementController;

    private void Start ( )
    {
        StartCoroutine ( FootStepCoroutine ( ) );
    }

    IEnumerator FootStepCoroutine( )
    {
        //while ( true )
        //{
        //    if ( movementController.movement.magnitude > 0.1f )
        //    {
        //        AudioManager.instance.PlaySfx ( footStepClip );
        //    }
            yield return new WaitForSeconds ( 1.0f );
        //}
    }
}
