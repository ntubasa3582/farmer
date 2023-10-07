using System;
using UnityEngine;
using UnityEngine.UI;

public class DayCounter : MonoBehaviour
{
    [SerializeField] float _timer;
    [SerializeField] Text _dayCountText;
    public event Action DayChange;
    int _dayCount;
    float _time;
    void Update()
    {
        //_timer変数にセットした数値ごとにif文の中身が実行される
        _time += Time.deltaTime;
        if (_time > _timer)
        {
            _time = 0;
            DayChange();//一定時間ごとにこのメソッドが呼ばれる
            _dayCount++;
            _dayCountText.text = _dayCount.ToString("0" + "日目");
        }
    }
}
