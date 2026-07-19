using System.Collections;
using UnityEngine;

[RequireComponent ( typeof ( AudioSource ) )]
public class SFXController : MonoBehaviour
{
    [SerializeField] AudioClip footStepClip;
    [SerializeField] AudioSource audioSource;
    [SerializeField] PlayerManager playerManager;

    private void Start ( )
    {
        StartCoroutine ( PlaySFXForMovement ( ) );
    }

    //public IEnumerator PlaySfx ( )
    //{
    //        audioSource.PlayOneShot ( footStepClip );
    //        yield return new WaitForSeconds ( footStepClip.length );
    //}

    IEnumerator PlaySFXForMovement( )
    {
        while ( true )
        {
            if ( playerManager != null && playerManager.movement.magnitude > 0.1f )
            {
                audioSource.PlayOneShot ( footStepClip );
            }
            yield return new WaitForSeconds ( footStepClip.length * 2.0f);
        }
    }
}
