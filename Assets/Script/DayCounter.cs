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
        //_timer�ϐ��ɃZ�b�g�������l���Ƃ�if���̒��g�����s�����
        _time += Time.deltaTime;
        if (_time > _timer)
        {
            _time = 0;
            DayChange();//��莞�Ԃ��Ƃɂ��̃��\�b�h���Ă΂��
        }
    }
}
