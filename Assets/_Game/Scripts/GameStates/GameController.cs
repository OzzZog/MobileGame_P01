using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Game Data")]
    [SerializeField] private float _timerCountDown;
    [SerializeField] private int _amountOfTapsFromPlayer;
    [SerializeField] private int _currentObjectInArray;
    public Gradient gradient;
    [SerializeField] private bool _startGameAfterCountdown = false;
    [SerializeField] private float _initialCountdown = 4f;

    [Header("Dependencies")]
    [SerializeField] public AudioSource _countDownAudioSource;
    [SerializeField] private AudioClip[] _clip;
    [SerializeField] private TouchManager _input;
    [SerializeField] private GameObject[] _gameUI;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private Slider _tapsToBreakObject;
    [SerializeField] private Image _sliderFill;
    [SerializeField] private TextMeshProUGUI _initialCountdownText;

    [Header("Breakable Object Settings")]
    [SerializeField] private BreakableObject[] _breakableObject;
    [SerializeField] private ObjectSpawner _objectSpawner;
    [SerializeField] private Transform _breakableObjectTransform;

    public int AmountOfTapsFromPlayer => _amountOfTapsFromPlayer;
    public int CurrentObjectInArray => _currentObjectInArray;
    public bool StartGameAfterCountdown => _startGameAfterCountdown;

    public AudioClip[] Clip => _clip;
    public TouchManager Input => _input;
    public GameObject[] GamePlayUI => _gameUI;

    public BreakableObject[] BreakableObject => _breakableObject;
    public ObjectSpawner ObjectSpawner => _objectSpawner;
    public Transform BreakableObjectTransform => _breakableObjectTransform;

    // Change something whenever the player taps, event from touch manager
    public void IncreaseTapCountCausedByPlayer()
    {
        _amountOfTapsFromPlayer++;
        _tapsToBreakObject.value++;
        _sliderFill.color = gradient.Evaluate(_tapsToBreakObject.normalizedValue);
    }

    public void ShakeObject()
    {
        BreakableObject shakeObject = FindObjectOfType<BreakableObject>();
        shakeObject.Shake();
    }

    public void ResetGameInfo()
    {
        _amountOfTapsFromPlayer = 0;
        _tapsToBreakObject.value = _amountOfTapsFromPlayer;

        _startGameAfterCountdown = false;
        _initialCountdown = 4f;
    }

    public void SetGameValues()
    {
        _timerCountDown = _breakableObject[_currentObjectInArray]._timeToBreakThisObject;
        _timerText.color = Color.white;
        _timerText.text = string.Format("{0:N}", _timerCountDown);

        // Slider
        _tapsToBreakObject.maxValue = _breakableObject[_currentObjectInArray]._tapsNeededToBreak;
        _tapsToBreakObject.minValue = 0;

        // Initial timer countdown
        _startGameAfterCountdown = false;
        _initialCountdown = 4f;
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
        }
        float seconds = _timerCountDown % 60;
        _timerText.text = string.Format("{0:N}", seconds);
    }
    
    public void StartingCountdown()
    {
        _initialCountdown -= Time.deltaTime;
        if (_initialCountdown > 1)
        {
            _startGameAfterCountdown = false;

            _initialCountdownText.gameObject.SetActive(true);
            int seconds = Mathf.FloorToInt(_initialCountdown % 60);
            _initialCountdownText.text = string.Format("{0}", seconds);
        }
        else if (_initialCountdown > 0)
        {
            _initialCountdownText.text = "Begin!";
        }
        else if (_initialCountdown <= 0)
        {
            _startGameAfterCountdown = true;
            _initialCountdown = 0;
            _initialCountdownText.gameObject.SetActive(false);
        }
    }
}
