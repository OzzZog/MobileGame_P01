using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using TMPro;
using UnityEditor;
using Unity.VisualScripting;

public class GamePlayState : State
{
    private GamesFSM _stateMachine;
    private GameController _controller;
    private BreakableObject _breakableObject;

    public GamePlayState(GamesFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();

        GamePlayUI.ShowUI(_controller.GamePlayUI[1]);
        AudioManager.PlayClip(_controller.Clip[0], 1);

        _controller.ResetGameInfo();
        _controller.SetGameValues();

        _breakableObject = _controller.ObjectSpawner.Spawn(_controller.BreakableObject[_controller.CurrentObjectInArray], _controller.BreakableObjectTransform);
    }

    public override void Exit()
    {
        base.Exit();

        _controller.ResetGameInfo();
        _controller.IncreaseDifficulty();

        //Object.Destroy(_breakableObject);
        _breakableObject.gameObject.SetActive(false);

        GamePlayUI.HideUI(_controller.GamePlayUI[1]);

        _controller.Input.AreWeInGamePlayState = false;
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();

        if (!_controller.StartGameAfterCountdown)
        {
            _controller.StartingCountdown();
        }

        else if (_controller.StartGameAfterCountdown)
        {
            _controller.Input.AreWeInGamePlayState = true;

            _controller.CountDown();

            if (_controller.AmountOfTapsFromPlayer == _controller.BreakableObject[4]._tapsNeededToBreak)
            {
                _stateMachine.ChangeState(_stateMachine.WinState);
            }
            else if (_controller.AmountOfTapsFromPlayer == _controller.BreakableObject[_controller.CurrentObjectInArray]._tapsNeededToBreak)
            {
                _stateMachine.ChangeState(_stateMachine.NextLevelState);
            }
            else if (StateDuration >= _controller.BreakableObject[_controller.CurrentObjectInArray]._timeToBreakThisObject)
            {
                _stateMachine.ChangeState(_stateMachine.LoseState);
            }
        }
    }
}
