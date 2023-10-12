using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameText : MonoBehaviour
{
    [SerializeField] List<Text> _gameTexts = new();
    [SerializeField] GameObject _playerObject;
    PlayerController _playerController;
    DayCounter _dayCounter;
    public enum TextName
    {
        /// <summary>“ú‚É‚¿ </summary>
        DayText,
        /// <summary>Ží </summary>
        SeedText,
    }

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _playerController = GameObject.FindObjectOfType<PlayerController>();
        _dayCounter = GetComponent<DayCounter>();
        _dayCounter = GameObject.FindObjectOfType<DayCounter>();
        //Debug.Log(_gameTexts[(int)TextName.DayCount].text);
    }
    private void Start()
    {
        //_gameTexts[(int)TextName.DayText].text = _dayCounter._dayCount.ToString("0" + "“ú–Ú");
        //_gameTexts[(int)TextName.SeedText].text = _playerController._plantCount.ToString("Žc‚è" + "0" + "ŒÂ");
    }
    private void OnEnable()
    {
        _dayCounter.DayChange += AddDayCount;
        _playerController.SeedCount += AddSeedCount;
    }

    private void OnDisable()
    {
        _dayCounter.DayChange -= AddDayCount;
        _playerController.SeedCount -= AddSeedCount;    
    }

    private void AddDayCount()
    {
        _gameTexts[(int)TextName.DayText].text = _dayCounter._dayCount.ToString("0"+ "“ú–Ú");
    }

    private void AddSeedCount()
    {
        _gameTexts[(int)TextName.SeedText].text = _playerController._plantCount.ToString("Žc‚è"+"0"+"ŒÂ");
    }



}
