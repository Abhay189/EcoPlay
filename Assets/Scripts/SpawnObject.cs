using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;

    void Start()
    {
        // Call the SpawnObject method when the script starts
        SpawnObject();
    }

    void SpawnObject()
    {
        // Check if the object prefab is assigned
        if (objectPrefab != null)
        {
            // Spawn the object from the prefab at the current position of this GameObject
            Instantiate(objectPrefab, transform.position, Quaternion.identity);

            // // Optionally, you can do something with the spawned object
            // // For example, you can set it as a child of the spawner
            // spawnedObject.transform.parent = transform;
        }
        else
        {
            Debug.LogError("Object prefab is not assigned in the inspector!");
        }
    }
}
