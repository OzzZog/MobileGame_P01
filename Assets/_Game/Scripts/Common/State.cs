using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public float StateDuration {  get; private set; }

    // run once when state is Entered
    public virtual void Enter()
    {
        StateDuration = -4f;
    }

    // run once when state is Exited
    public virtual void Exit()
    {

    }

    // for Physics
    public virtual void FixedTick()
    {

    }

    public virtual void Tick()
    {
        StateDuration += Time.deltaTime;
    }
}
