using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IEnemyState
{
    Enemy _parent;

    private float speed = 0.1f;

    public void Begin(Enemy enemy)
    {
        _parent = enemy;
    }

    public void End()
    {
    }

    public void Update()
    {
        _parent.transform.position = Vector3.MoveTowards(_parent.transform.position, _parent.player.transform.position, speed);
    }

}
