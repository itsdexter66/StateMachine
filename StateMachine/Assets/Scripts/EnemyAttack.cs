using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    float distance;


    // Update is called once per frame
    void Update()
    {
        Attacking();
    }

    //Vector2.Distance
    void Attacking()
    {
       distance = Vector2.Distance(player.transform.position, enemy.transform.position);
        if (distance <= 1.5)
        {
            Debug.Log("Attacked");
        }
    }
}
