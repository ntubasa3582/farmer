using System;
using UnityEngine;
using UnityEngine.UI;

public class DayCounter : MonoBehaviour
{
    [SerializeField] float _timer;//1�������b�ɂ��邩���w��ł���
    public event Action DayChange;//���̃��\�b�h���Ă΂ꂽ����ɂ���ύX����
    public int _dayCount;//���ɂ������̕ϐ��ɕۑ����Ă���
    float _time;//deltaTime�̒l��ϐ��̒��ɓ���Ă���
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
