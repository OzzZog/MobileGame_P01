using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("Game Data")]
    [SerializeField] private float _tapLimitDuration;
    private int _amountOfTapsFromPlayer;
    [Header("Dependencies")]
    [SerializeField] private AudioClip[] _clip;
    [SerializeField] private TouchManager _input;
    [SerializeField] private GameObject[] _gameUI;
    [SerializeField] private Timer _timer;
    [SerializeField] private TextMeshProUGUI _timerText;

    public float TapLimitDuration => _tapLimitDuration;
    public int AmountOfTapsFromPlayer => _amountOfTapsFromPlayer;

    public AudioClip[] Clip => _clip;
    public TouchManager Input => _input;
    public GameObject[] GamePlayUI => _gameUI;
    public Timer Timer => _timer;
    public TextMeshProUGUI TimerText => _timerText;
}
