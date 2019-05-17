using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesSubscriber
{
    Dictionary<string, IState> _states = new Dictionary<string, IState>();

    public Dictionary<string, IState> States { get; private set; }

    public void Push(string name, IState state)
    {
        _states.Add(name, state);
    }

    public IState GetState(string name)
    {
        _states.TryGetValue(name, out IState output);
        return output;
    }
}
