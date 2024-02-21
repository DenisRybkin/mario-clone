using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IgnitableStaticEnemy : StaticEnemy
{
    public int health = 10;
    private HealthbarManager? healthbarManager;

    private void Awake()
    {
        healthbarManager = GetComponentInChildren<HealthbarManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player is dead");
            collision.gameObject.GetComponent<Player>().Damage();
            return;
        }
        if(collision.gameObject.tag == "Fire")
        {
            Debug.Log("health_" + health.ToString());
            health--;
            if(health <= 0)
                Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            Destroy(collision.gameObject);
            health--;
            healthbarManager.TakeDamage(10);
            if (health <= 0)
                Destroy(gameObject);
        }
    }
}
