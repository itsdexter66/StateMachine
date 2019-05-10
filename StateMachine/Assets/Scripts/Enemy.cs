using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    IEnemyState _currentstate;

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
