using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Game Data")]
    [SerializeField] private float _tapLimitDuration;
    private float _timerCountDown;
    private int _amountOfTapsFromPlayer;

    [Header("Dependencies")]
    [SerializeField] private AudioClip[] _clip;
    [SerializeField] private TouchManager _input;
    [SerializeField] private GameObject[] _gameUI;
    [SerializeField] private Timer _timer;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private Slider _tapsToBreakObject;
    [SerializeField] private BreakableObject _breakableObject;

    public float TapLimitDuration => _tapLimitDuration;
    public float TimerCountDown => _timerCountDown;
    public int AmountOfTapsFromPlayer => _amountOfTapsFromPlayer;

    public AudioClip[] Clip => _clip;
    public TouchManager Input => _input;
    public GameObject[] GamePlayUI => _gameUI;
    public Timer Timer => _timer;
    public TextMeshProUGUI TimerText => _timerText;

    public void IncreaseTapCountCausedByPlayer()
    {
        _amountOfTapsFromPlayer++;
        _tapsToBreakObject.value++;
    }

    public void ResetTapCounter()
    {
        _amountOfTapsFromPlayer = 0;
    }

    public void SetTimerCountDown()
    {
        _timerCountDown = _tapLimitDuration;
    }

    public void SetSlider()
    {
        _tapsToBreakObject.maxValue = _tapLimitDuration;
        _tapsToBreakObject.minValue = 0;
    }

    public void ResetSlider()
    {
        _tapsToBreakObject.value = _amountOfTapsFromPlayer;
    }

    public void CountDown()
    {
        if (_timerCountDown > 0)
        {
            _timerCountDown -= Time.deltaTime;
        }
        else if (_timerCountDown <= 0)
        {
            _timerCountDown = 0;

            _timerText.color = Color.red;
        }

        int minuets = Mathf.FloorToInt(_timerCountDown / 60);
        int seconds = Mathf.FloorToInt(_timerCountDown % 60);
        _timerText.text = string.Format("{0:00}:{1:00}", minuets, seconds);
    }
}
