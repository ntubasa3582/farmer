using System;
using UnityEngine;
using UnityEngine.UI;

public class DayCounter : MonoBehaviour
{
    [SerializeField] float _timer;
    public event Action DayChange;
    public int _dayCount;
    float _time;
    private void Awake()
    {
        DayChange();
    }
    void Update()
    {
        //_timer変数にセットした数値ごとにif文の中身が実行される
        _time += Time.deltaTime;
        if (_time > _timer)
        {
            _time = 0;
            _dayCount++;
            DayChange();//一定時間ごとにこのメソッドが呼ばれる
        }
    }
}
