using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineMB : MonoBehaviour
{
    public State CurrentState {  get; private set; }
    private State _previousState;

    private bool _inTransition = false;

    public void ChangeState(State newState)
    {
        // ensure we are ready for a new state
        if (CurrentState == newState || _inTransition)
            return;
        ChangeStateSequence(newState);
    }

    private void ChangeStateSequence(State newState)
    {
        _inTransition = true;
        // run our exit sequence before moving to new state
        CurrentState?.Exit();
        StoreStateAsPrevious(newState);

        CurrentState = newState;

        // begin our new EnterSequence
        CurrentState?.Enter();
        _inTransition = false;
    }

    private void StoreStateAsPrevious(State newState)
    {
        // if there is no previous state, this is our first
        if (_previousState == null && newState != null)
            _previousState = newState;
        // otherwise, store our current state as previous state
        else if (_previousState != null && CurrentState != null)
            _previousState = CurrentState;
    }

    public void ChangeStateToPrevious()
    {
        if (_previousState != null)
            ChangeState(_previousState);
        else
            Debug.LogWarning("This is no previous state to change to!");
    }

    // virtual allows us to override in our FSM to check for 'AnyState' types of conditions
    protected virtual void Update()
    {
        // simulate update ticks in states
        if (CurrentState != null && !_inTransition)
            CurrentState.Tick();
    }

    protected virtual void FixedUpdate()
    {
        // simulate FixedUpdate in states
        if (CurrentState != null && !_inTransition)
            CurrentState.FixedTick();
    }

    protected virtual void OnDestroy()
    {
        CurrentState?.Exit();
    }
}
