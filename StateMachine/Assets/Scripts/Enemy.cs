using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    IEnemyState _currentstate;
    StatesSubscriber _ss = new StatesSubscriber();

    public GameObject player;
    private float maxSearchRange = 10.0f;
    private float distance;

    void Awake()
    {
        _ss.Push("Wander", new WanderState());
        _ss.Push("Chase", new ChaseState());
        _ss.Push("Attack", new AttackState());

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
        //TODO: Make the dictonary subscribers list
        if (distance <= maxSearchRange)
        {
            ChangeState(_ss.GetState("Wander") as IEnemyState);
        }
        else
        {
            ChangeState(_ss.GetState("Chase") as IEnemyState);
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
