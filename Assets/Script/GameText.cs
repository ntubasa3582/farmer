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
        /// <summary>���ɂ� </summary>
        DayText,
        /// <summary>��</summary>
        SeedText,
        /// <summary>���n������</summary>
        FruitsText,
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
        _dayCounter.DayChange += AddDayCount;//�f���Q�[�g�o�^
        _playerController.SeedCount += AddSeedCount;
        _playerController.FruitsCount += AddFruitsCount;
    }

    private void OnDisable()
    {
        _dayCounter.DayChange -= AddDayCount;//�f���Q�[�g�o�^������
        _playerController.SeedCount -= AddSeedCount;  
        _playerController.FruitsCount -= AddFruitsCount;
    }

    private void AddDayCount()
    {
        //_dayCount�̒l���e�L�X�g�ŕ\�����Ă���
        _gameTexts[(int)TextName.DayText].text = _dayCounter._dayCount.ToString("0"+ "����");
    }

    private void AddSeedCount()
    {
        //_plantCount�̒l���e�L�X�g�ŕ\�����Ă���
        _gameTexts[(int)TextName.SeedText].text = _playerController._plantCount.ToString("�c��"+"0"+"��");
    }
    private void AddFruitsCount()
    {
        _gameTexts[(int)TextName.FruitsText].text = _playerController._fruitsCount.ToString("0" + "���n");
    }



}
