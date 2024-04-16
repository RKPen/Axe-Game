using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AxeSpawner : MonoBehaviour
{
    public GameObject axePrefab;
    public GameObject player;
    private float moveSpeed = 7f;
    public float spawnRate = 2f;
    private Vector2 moveDirection;
    public Vector2 throwForce = new Vector2(-200, 110);


    private void Start()
    {
        StartCoroutine(SpawnAxes());
    }

    private void Update()
    {
        this.transform.Rotate(0f, 0f, 2f);
    }
    IEnumerator SpawnAxes()
    {
        if (player.GetComponent<PlayerHealth>().getLiveHealth() > 0)
        {
            yield return new WaitForSeconds(spawnRate);

            SpawnAxe();
        }
    }

    void SpawnAxe()
    {
        // Debug.Log(player.GetComponent<PlayerHealth>().getLiveHealth());
        Vector2 spawnPosition = new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x + 1f, 3f);
        GameObject axe = Instantiate(axePrefab, spawnPosition, Quaternion.identity);

        Rigidbody2D rb = axe.GetComponent<Rigidbody2D>();
   
         Vector2 directionToPlayer = (player.transform.position - axe.transform.position).normalized;

        float distanceToPlayer = Vector2.Distance(axe.transform.position, player.transform.position);
        
        float forceMagnitude = moveSpeed * distanceToPlayer * 20; 

        rb.AddForce(directionToPlayer * forceMagnitude);
        Destroy(axe , 5f);
    }
}
