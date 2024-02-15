using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoseState : State
{
    private GamesFSM _stateMachine;
    private GameController _controller;

    public GameLoseState(GamesFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("You Lose!");


        // Play lose audio, hide gameplay UI, show lose UI
        AudioManager.PlayClip(_controller.Clip[1], 1);
        GamePlayUI.HideUI(_controller.GamePlayUI[1]);
        GamePlayUI.ShowUI(_controller.GamePlayUI[3]);
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
    }
}
