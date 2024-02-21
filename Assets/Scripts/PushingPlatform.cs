using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingPlatform : MonoBehaviour
{
    public float jumpForce = 40;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") 
        {
            collision.rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
