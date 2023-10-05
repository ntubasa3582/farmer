using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassMnager : MonoBehaviour
{
    [Header("�����͈̔͂̍Œ�l��0�ōō��l��1")]
    [SerializeField] int[] _rnd = null; //
    [SerializeField] Material[] _material;//�ύX�������}�e���A�����Z�b�g����
    [SerializeField] Mesh[] _mesh;//�ύX���������b�V�����Z�b�g����
    MeshRenderer _meshRenderer;
    MeshFilter _meshFilter;
    DayCounter _dayCounter;
    bool[] _levelSwich = new bool[3];//���x���A�b�v�̃R�[�h��1�񂾂����s����
    int _dayCount = 0;//���ɂ����J�E���g����
    int _xp = 0;//�o���l
    int _level = 0;//���̌o���l����ɓ������烌�x����1���グ��
    private void Awake()
    {
        _dayCounter = GameObject.FindObjectOfType<DayCounter>();
        _meshFilter = GetComponent<MeshFilter>();
        _meshRenderer = GetComponent<MeshRenderer>();
        for (int i = 0; i < _meshRenderer.materials.Length; i++)
        {
            _meshRenderer.materials[i] = GetComponent<Material>();
        }
    }

    private void OnEnable()
    {
        _dayCounter.DayChange += NextDay;
    }

    private void OnDisable()
    {
        _dayCounter.DayChange -= NextDay;
    }

    private void Update()
    {
        if (_xp >= 5 && _xp < 10)//5���x���ȏ�ɂȂ������Ƀ��x�����P�ɏグ��
        {
            if (_levelSwich[0] == false)
            {
                LevelUp();
                _levelSwich[0] = true;
            }
        }
        else if (_xp >= 10 && _xp < 15)//10���x���ȏ�ɂȂ������Ƀ��x����2�ɏグ��
        {
            if (_levelSwich[1] == false)
            {
                LevelUp();
                _levelSwich[1] = true;
            }
        }
        else if (_xp >= 15 && _xp < 20)//15���x���ȏ�ɂȂ������Ƀ��x����3�ɏグ��
        {
            if (_levelSwich[2] == false)
            {
                LevelUp();
                _levelSwich[2] = true;
            }
        }
    }
    public void NextDay()
    {
        //�{�^���������ꂽ�烉���_���Ȓl��_xp�ɓ����
        int Ran;
        _dayCount++;
        Debug.Log(_dayCount + "����");
        Ran = Random.Range(_rnd[0], _rnd[1]);
        _xp += Ran;
    }

    public void LevelUp()
    {
        //OnMat();//���x�����オ�����Ƃ���Method���Ăяo��
        _level += 1;//���x����1�グ��
        Debug.Log("����" + _level + "���x���ł�");
        MaterialChange();
    }
    void MaterialChange()
    {
        //���x�����オ�����Ƃ��Ƀ��b�V���ƃ}�e���A����ύX����
        switch (_level)
        {
            case 1:
                _meshFilter.mesh = _mesh[0];
                _meshRenderer.material = _material[0];
                break;
            case 2:
                _meshFilter.mesh = _mesh[1];
                _meshRenderer.material = _material[1];
                break;
            case 3:
                _meshFilter.mesh = _mesh[2];
                _meshRenderer.material = _material[2];
                break;
        }
    }
}
