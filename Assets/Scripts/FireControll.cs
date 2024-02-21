using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControll : MonoBehaviour
{
    public int count = 11;
    public float speed;
    public float lifetime;
    public float distance;

    public bool isShoot = false;

    void Update()
    {
        if (isShoot) Shoot();
    }

    private void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void Shoot()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Get fire");
            var player = collision.GetComponent<Player>();
            player.AddFires(count); 
            //player.AddCoin(count);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
