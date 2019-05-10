using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    IEnemyState _currentstate;
    public GameObject player;
    private float maxSearchRange = 10.0f;
    private float distance;


    void Awake()
    {
        ChangeState(new WanderState());
    }

    void Start()
    {
        
    }

    void Update()
    {
        _currentstate.Update();
        distance = Vector3.Distance(player.transform.position, transform.position);
        Searching();
    }

    void Searching()
    {
        if (distance <= maxSearchRange)
        {
            ChangeState(new ChaseState());
        } else
        {
            ChangeState(new WanderState());
        }
    }

    void ChangeState(IEnemyState state)
    {
        if(_currentstate != null)
        {
            _currentstate.End();
        }

        _currentstate = state;

        _currentstate.Begin(this);
    }
}
