using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class GameNextLevelState : State
{
    private GamesFSM _stateMachine;
    private GameController _controller;

    public GameNextLevelState(GamesFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }
    public override void Enter()
    {
        base.Enter();

        GamePlayUI.ShowUI(_controller.GamePlayUI[2]);
        AudioManager.PlayClip(_controller.Clip[0], 1);
    }

    public override void Exit()
    {
        base.Exit();

        GamePlayUI.HideUI(_controller.GamePlayUI[2]);
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
