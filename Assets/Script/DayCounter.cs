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
        //_timer�ϐ��ɃZ�b�g�������l���Ƃ�if���̒��g�����s�����
        _time += Time.deltaTime;
        if (_time > _timer)
        {
            _time = 0;
            DayChange();//��莞�Ԃ��Ƃɂ��̃��\�b�h���Ă΂��
            _dayCount++;
            _dayCountText.text = _dayCount.ToString("0" + "����");
        }
    }
}
