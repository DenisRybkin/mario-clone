using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rg;

    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Invoke("FallPlatform", 1f);
            Destroy(gameObject, 3f);
        }
    }

    void FallPlatform()
    {
        rg.isKinematic = false;
    }
}
