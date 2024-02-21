using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour
{
    public int count = 5;
    public float speed;
    private Vector3[] positions;

    private int currentTarget;

    public void Awake()
    {
        float currentXPosition = transform.position.x;
        positions = new Vector3[2] { new Vector3(transform.position.x - 2, transform.position.y ,0), new Vector3(transform.position.x + 2, transform.position.y, 0) };
    }

    public void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, positions[currentTarget], speed);

        if(transform.position == positions[currentTarget])
        {
            if (currentTarget < positions.Length - 1)
                currentTarget++;
            else currentTarget = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player is dead");
            collision.gameObject.GetComponent<Player>().Damage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Enemy is dead");
            var player = collision.GetComponent<Player>();
            player.SpeedBonus();
            player.AddCoin(count);
            Destroy(gameObject);
        } 
    }
}
