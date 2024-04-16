using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int liveHealth;
    public int healthIncrease = 5; 
    public int healthDecreaseAmount = 20;
    public float flickerDuration = 1.2f;
    public float flickerDelay = 0.2f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        liveHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        Debug.Log("Player's Health : " + liveHealth);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            IncreaseHealth(healthIncrease);
            Destroy(other.gameObject);
            Debug.Log("Apple hit the player. Health: " + liveHealth);
        }
        else if (other.gameObject.CompareTag("Axe"))
        {
            TakeDamage(healthDecreaseAmount);
            Debug.Log("Axe hit the player. Health: " + liveHealth);

        }
    }

    public void IncreaseHealth(int amount)
    {
        liveHealth += amount;
        liveHealth = Mathf.Min(liveHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        liveHealth -= damage;
        if (liveHealth <= 0)
        {
            Debug.Log("GAME OVER!!!!");
            gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(FlickerEffect());
        }
    }

    IEnumerator FlickerEffect()
    {
        float elapsedTime = 0f;
        while (elapsedTime < flickerDuration)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(flickerDelay);
            elapsedTime += flickerDelay;
        }
        spriteRenderer.enabled = true;
    }

    public int getLiveHealth(){

        return liveHealth;
    }

    public int getMaxHealth(){

        return maxHealth;
    }
}









