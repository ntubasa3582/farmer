using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameText : MonoBehaviour
{
    [SerializeField] List<Text> _gameTexts = new();
    PlayerController _playerController;
    DayCounter _dayCounter;
    public enum TextName
    {
        /// <summary>日にち </summary>
        DayText,
        /// <summary>種 </summary>
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
    private void OnEnable()
    {
        _dayCounter.DayChange += AddDayCount;//デリゲート登録
        _playerController.SeedCount += AddSeedCount;
    }

    private void OnDisable()
    {
        _dayCounter.DayChange -= AddDayCount;//デリゲート登録を解除
        _playerController.SeedCount -= AddSeedCount;    
    }

    private void AddDayCount()
    {
        //_dayCountの値をテキストで表示している
        _gameTexts[(int)TextName.DayText].text = _dayCounter._dayCount.ToString("0"+ "日目");
    }

    private void AddSeedCount()
    {
        //_plantCountの値をテキストで表示している
        _gameTexts[(int)TextName.SeedText].text = _playerController._plantCount.ToString("残り"+"0"+"個");
    }



}
