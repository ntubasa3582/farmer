using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCounter : MonoBehaviour
{
    [SerializeField] float _timer;
    public event Action DayChange;
    float _time;
    void Update()
    {
        //_timer変数にセットした数値ごとにif文の中身が実行される
        _time += Time.deltaTime;
        if (_time > _timer)
        {
            _time = 0;
            DayChange();//一定時間ごとにこのメソッドが呼ばれる
        }
    }
}
