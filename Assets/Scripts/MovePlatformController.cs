using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformController : MonoBehaviour
{
    public float speed;
    private Vector3[] positions;

    private int currentTarget;

    public void Awake()
    {
        float currentXPosition = transform.position.x;
        positions = new Vector3[2] { new Vector3(currentXPosition - 6, transform.position.y, 6), new Vector3(currentXPosition + 5, transform.position.y, 0) };
    }

    public void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, positions[currentTarget], 0.08f);

        if (transform.position == positions[currentTarget])
        {
            if (currentTarget < positions.Length - 1)
                currentTarget++;
            else currentTarget = 0;
        }
    }
}
