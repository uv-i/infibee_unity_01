using System.Collections;
using UnityEngine;

public class CoroutineExplanation : MonoBehaviour
{
    bool canContinue = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine ( TimeDelay ( ) );
        StartCoroutine ( BoolDelay ( ) );
    }

    IEnumerator TimeDelay()
    {
        Debug.Log("Time Delay Coroutine started");
        yield return new WaitForSeconds(5f);
        Debug.Log("Time Delay Coroutine ended after 5 second");
        canContinue = true;
        Debug.Log ( "Can Continue become true in Time delay" );
    }

    IEnumerator BoolDelay ( )
    {
        Debug.Log ( " Bool Delay Coroutine started" );
        yield return new WaitUntil ( ( ) => canContinue );
        Debug.Log ( "Can Continue Is True" );
        yield return new WaitForSeconds ( 3f );
        Debug.Log ( "Bool Delay Coroutine ended after 3 second" );
    }
}
