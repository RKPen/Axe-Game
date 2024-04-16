using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject applePrefab;
    public float spawnRate = 2f;
    public float min = 0.5f;
    public float max = 1.25f;

    private void Start()
    {
        StartCoroutine(SpawnApples());
    }

    IEnumerator SpawnApples()
    {
        if (true)
        {
            yield return new WaitForSeconds(spawnRate);


            int applesToSpawn = Random.Range(0, 1);
            if(applesToSpawn == 0 )
            {
                SpawnApple();
            }


        }
    }

    void SpawnApple()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        float xPos = Random.Range(-screenBounds.x, screenBounds.x);
        Vector3 spawnPosition = new Vector3(xPos, screenBounds.y, 0);

        GameObject appleInstance = Instantiate(applePrefab, spawnPosition, Quaternion.identity);
        float size = Random.Range(min, max);
        appleInstance.transform.localScale = new Vector3(size, size, 1);
        Destroy(appleInstance , 5f);
    }

}
