using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    IEnemyState _currentstate;
    readonly StatesSubscriber _ss = new StatesSubscriber();

    readonly float _maxSearchRange = 10.0f;
    float _distance;

    public GameObject player;

    void Awake()
    {
        _ss.Push("Wander", new WanderState());
        _ss.Push("Chase", new ChaseState());
        _ss.Push("Attack", new AttackState());

        ChangeState(new WanderState());
    }

    void Update()
    {
        _currentstate.Update();
        _distance = Vector3.Distance(player.transform.position, transform.position);
        Searching();
        Attacking();
    }

    void Searching()
    {
        if (_distance <= 1.5f)
        {
            ChangeState(_ss.GetState("Attack") as IEnemyState);
        } 
        else if (_distance > 1.5f && _distance >= _maxSearchRange) 
        {
            ChangeState(_ss.GetState("Wander") as IEnemyState);
        }
        else
        {
            ChangeState(_ss.GetState("Chase") as IEnemyState);
        }
    }

    void Attacking()
    {
        
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
