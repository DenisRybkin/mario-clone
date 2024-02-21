using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScale : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var player = collision.GetComponent<Player>();
            player.ScaleBonus();
            Destroy(gameObject);
        }
    }
}
