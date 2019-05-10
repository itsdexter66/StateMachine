using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void Begin(Enemy enemy);
    void End();
    void Update();
}
