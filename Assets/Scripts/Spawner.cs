using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float minZ;
    public float maxZ;

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown ( KeyCode.S ) )
        {
            SpawnObject ( ); 
            Debug.Log ( "S Clicked" );
        }
    }

    void SpawnObject ( )
    {
        var zValue = Random.Range ( minZ, maxZ );
        GameObject go = Instantiate ( prefab );
        go.transform.position = new Vector3( go.transform.position.x, go.transform.position.y, zValue);
    }
}
