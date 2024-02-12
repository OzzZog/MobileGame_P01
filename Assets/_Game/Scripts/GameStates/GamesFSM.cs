using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameController))]
public class GamesFSM : StateMachineMB
{
    private GameController _controller;

    // state variables here
    public GameSetupState SetupState {  get; private set; }
    public GamePlayState PlayState { get; private set; }

    private void Awake()
    {
        _controller = GetComponent<GameController>();
        // state instantiation here
        SetupState = new GameSetupState(this, _controller);
        PlayState = new GamePlayState(this, _controller);
    }

    private void Start()
    {
        ChangeState(SetupState);
    }
}
