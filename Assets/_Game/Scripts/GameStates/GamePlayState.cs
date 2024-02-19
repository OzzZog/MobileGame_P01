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
        AudioManager.PlayClip(_controller.Clip[0], 1);

        _controller.ResetTapCounter();
        _controller.SetTimerCountDown();

        _controller.ResetSlider();
        _controller.SetSlider();
    }

    public override void Exit()
    {
        base.Exit();

        _controller.ResetTapCounter();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();

        _controller.CountDown();

        Debug.Log("Number of Taps: " + _controller.AmountOfTapsFromPlayer);

        if(_controller.AmountOfTapsFromPlayer == 15)
        {
            _stateMachine.ChangeState(_stateMachine.WinState);
        }
        else if(StateDuration >= _controller.TapLimitDuration)
        {
            _stateMachine.ChangeState(_stateMachine.LoseState);
        }
    }
}
