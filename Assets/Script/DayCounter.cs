using System;
using UnityEngine;
using UnityEngine.UI;

public class DayCounter : MonoBehaviour
{
    [SerializeField] float _timer;//1日を何秒にするかを指定できる
    public event Action DayChange;//このメソッドが呼ばれたら日にちを変更する
    public int _dayCount;//日にちをこの変数に保存しておく
    float _time;//deltaTimeの値を変数の中に入れておく
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
