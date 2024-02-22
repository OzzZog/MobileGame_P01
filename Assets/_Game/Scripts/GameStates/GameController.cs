using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Game Data")]
    private float _timerCountDown;
    private int _amountOfTapsFromPlayer;
    private int _currentObjectInArray;

    [Header("Dependencies")]
    [SerializeField] private AudioClip[] _clip;
    [SerializeField] private TouchManager _input;
    [SerializeField] private GameObject[] _gameUI;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private Slider _tapsToBreakObject;

    [Header("Breakable Objects")]
    [SerializeField] private BreakableObject[] _breakableObject;
    [SerializeField] private ObjectSpawner _objectSpawner;
    [SerializeField] private Transform _breakableObjectTransform;

    public float TimerCountDown => _timerCountDown;
    public int AmountOfTapsFromPlayer => _amountOfTapsFromPlayer;
    public int CurrentObjectInArray => _currentObjectInArray;

    public AudioClip[] Clip => _clip;
    public TouchManager Input => _input;
    public GameObject[] GamePlayUI => _gameUI;
    public TextMeshProUGUI TimerText => _timerText;

    public BreakableObject[] BreakableObject => _breakableObject;
    public ObjectSpawner ObjectSpawner => _objectSpawner;
    public Transform BreakableObjectTransform => _breakableObjectTransform;

    // Change something whenever the player taps, event from touch manager
    public void IncreaseTapCountCausedByPlayer()
    {
        _amountOfTapsFromPlayer++;
        _tapsToBreakObject.value++;
    }

    public void ResetGameInfo()
    {
        _amountOfTapsFromPlayer = 0;
        _tapsToBreakObject.value = _amountOfTapsFromPlayer;
    }

    public void SetGameValues()
    {
        _timerCountDown = _breakableObject[_currentObjectInArray]._timeToBreakThisObject;

        _tapsToBreakObject.maxValue = _breakableObject[_currentObjectInArray]._tapsNeededToBreak;
        _tapsToBreakObject.minValue = 0;

        //Debug.Log(_currentObjectInArray);
        //Debug.Log("Taps to break this object: " + _breakableObject[_currentObjectInArray]._tapsNeededToBreak);
        //Debug.Log("Taps to break this object: " + _breakableObject[_currentObjectInArray]._timeToBreakThisObject);
    }

    public void IncreaseDifficulty()
    {
        _currentObjectInArray++;
    }

    public void CountDown()
    {
        _timerCountDown -= Time.deltaTime;
        if (_timerCountDown > 3)
        {
            _timerText.color = Color.white;
        }
        else if (_timerCountDown < 3)
        {
            _timerText.color = Color.red;
        }
        else if (_timerCountDown <= 0)
        {
            _timerCountDown = 0;

            //_timerText.color = Color.red;
        }

        float seconds = _timerCountDown % 60;
        _timerText.text = string.Format("{0:N}", seconds);
    }
}
