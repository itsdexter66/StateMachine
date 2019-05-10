using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float maxSearchRange = 10.0f;
    private float distance;
    private float speed = 0.1f;
    public GameObject player;

  

    private void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        Searching();
    }

    void Searching()
    {
        if (distance <= maxSearchRange)
        {
            MoveTowards();
        }
    }

    void MoveTowards()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
    }
}
