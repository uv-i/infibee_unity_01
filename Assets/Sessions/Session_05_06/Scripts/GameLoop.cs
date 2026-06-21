using UnityEngine;

public class GameLoop : MonoBehaviour
{
    // Called when the script instance is being loaded
    private void Awake ( )
    {
        Debug.Log ( "Called On Awake");
    }
    // Called when the object becomes enabled and active
    private void OnEnable ( )
    {
        Debug.LogWarning ( "Called On Enable" );
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.LogError ( "Called On Start" );
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log ( "Called On Update" );
    }
    // Called when the behaviour becomes disabled or inactive
    private void OnDisable ( )
    {
        Debug.LogWarning ( "Called <color=blue>On Disable</color>" );
    }
    // This function is called when the MonoBehaviour will be destroyed
    private void OnDestroy ( )
    {
        Debug.Log ( "Called On Destroy" );
    }
}
