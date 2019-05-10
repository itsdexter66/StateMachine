using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IEnemyState
{
    Enemy _parent;

    public void Begin(Enemy enemy)
    {
        _parent = enemy;
    }

    public void End()
    {
    }

    public void Update()
    {
    }
}
