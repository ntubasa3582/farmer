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
        //_timer�ϐ��ɃZ�b�g�������l���Ƃ�if���̒��g�����s�����
        _time += Time.deltaTime;
        if (_time > _timer)
        {
            _time = 0;
            _dayCount++;
            DayChange();//��莞�Ԃ��Ƃɂ��̃��\�b�h���Ă΂��
        }
    }
}
