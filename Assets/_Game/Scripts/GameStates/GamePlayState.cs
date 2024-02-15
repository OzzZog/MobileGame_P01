using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using TMPro;

public class GamePlayState : State
{
    private GamesFSM _stateMachine;
    private GameController _controller;

    public GamePlayState(GamesFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("Listen for Player Inputs");
        GamePlayUI.HideUI(_controller.GamePlayUI[0]);
        GamePlayUI.ShowUI(_controller.GamePlayUI[1]);
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

        _controller.Timer.CountDown(_controller.TapLimitDuration, _controller.TimerText);

        if(_controller.Input.IsTapPressed == true)
        {
            //_controller.Input._numberOfTaps.ToString();
            Debug.Log(_controller.Input._numberOfTaps.ToString());
        }
        if(_controller.Input._numberOfTaps == 10)
        {
            _stateMachine.ChangeState(_stateMachine.WinState);
        }
        else if(StateDuration >= _controller.TapLimitDuration)
        {
            _stateMachine.ChangeState(_stateMachine.LoseState);
        }
    }
}
