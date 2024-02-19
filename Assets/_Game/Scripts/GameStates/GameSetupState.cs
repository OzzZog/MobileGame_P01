using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetupState : State
{
    private GamesFSM _stateMachine;
    private GameController _controller;

    // this is our 'constructor', called whn this state is created
    public GameSetupState(GamesFSM stateMachine, GameController controller)
    {
        // hold on to our parameters in our class variables for reuse
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();

        GamePlayUI.ShowUI(_controller.GamePlayUI[0]);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();

        /*
        if (StateDuration >= _controller.TapLimitDuration)
        {
            _stateMachine.ChangeState(_stateMachine.PlayState);
        }
        */
    }
}
