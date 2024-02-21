using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public int livels;
    public int livelsMax;

    public float speed;
    private Vector3[] positions;
    private int currentTarget;
    private HealthbarManager? healthbarManager;

    public void Awake()
    {
        float currentXPosition = transform.position.x;
        healthbarManager = GetComponentInChildren<HealthbarManager>();
        if (positions == null)
            positions = new Vector3[2] { 
                new Vector3(transform.position.x - 12, transform.position.y, 0),
                new Vector3(transform.position.x + 12, transform.position.y, 0) 
            };
    }

    public void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, positions[currentTarget], speed);

        if (transform.position == positions[currentTarget])
        {
            if (currentTarget < positions.Length - 1)
                currentTarget++;
            else currentTarget = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player is dead");
            collision.gameObject.GetComponent<Player>().Damage();
           
        }
        if (collision.gameObject.tag == "BossWeapon")
        {
            Destroy(collision.gameObject);
            if (livels < livelsMax)
            {
                livels++;
                healthbarManager.Heal(100 / livelsMax);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BossWeapon")
        {
            Destroy(collision.gameObject);
            livels--;
            if (livels <= 0) Dead();
            healthbarManager.TakeDamage(34);
            Destroy(collision.gameObject);
        } 
    }

    private void Dead()
    {
        SceneManager.LoadScene(2);
        Destroy(gameObject);
    }
}
