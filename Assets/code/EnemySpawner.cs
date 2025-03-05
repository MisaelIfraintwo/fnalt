using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] prefabs; 
    public float spawnInterval = 2f; 

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        InvokeRepeating("SpawnObject", 1f, spawnInterval);
    }

    void SpawnObject()
    {
        if (prefabs.Length == 0) return;

      
        int index = Random.Range(0, prefabs.Length);
        GameObject prefabToSpawn = prefabs[index];

        
        Vector2 spawnPosition = GetRandomScreenPosition();


        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }

    Vector2 GetRandomScreenPosition()
    {

        float screenX = Random.Range(mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x,
                                     mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x);
        
        float screenY = Random.Range(mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).y,
                                     mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y);

        return new Vector2(screenX, screenY);
    }
}
