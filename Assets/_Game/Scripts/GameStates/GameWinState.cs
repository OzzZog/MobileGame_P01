using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinState : State
{
    private GamesFSM _stateMachine;
    private GameController _controller;

    public GameWinState(GamesFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }
    public override void Enter()
    {
        base.Enter();

        // Play win audio, hide gameplay UI, show win UI
        AudioManager.PlayClip(_controller.Clip[1], 1);
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
