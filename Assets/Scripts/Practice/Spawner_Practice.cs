using UnityEngine;

public class Spawner_Practice : MonoBehaviour
{
    public GameObject prefab;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            SpawnObject();
        Debug.Log("S Clicked");
    }

    void SpawnObject()
    {
        float xValue = Random.Range(minX, maxX);
        float yValue = Random.Range(minY, maxY);
        float zValue = Random.Range(minZ, maxZ);

        GameObject go = Instantiate(prefab);
        go.transform.position = new Vector3(xValue, yValue, zValue);
    }
}
