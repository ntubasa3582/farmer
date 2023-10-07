using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GrassMnager : MonoBehaviour
{
    [Header("�����͈̔͂̍Œ�l��0�ōō��l��1")]
    [SerializeField] int[] _rnd = null; //
    [SerializeField] Material[] _material;//�ύX�������}�e���A�����Z�b�g����
    [SerializeField] Mesh[] _mesh;//�ύX���������b�V�����Z�b�g����
    MeshRenderer _meshRenderer;
    MeshFilter _meshFilter;
    MeshCollider _meshCollider;
    DayCounter _dayCounter;
    Transform _transform;
    bool[] _levelSwich = new bool[100];//���x���A�b�v�̃R�[�h��1�񂾂����s����
    int _dayCount = 0;//���ɂ����J�E���g����
    int _xp = 0;//�o���l
    int _level = 0;//���̌o���l����ɓ������烌�x����1���グ��
    float _random;
    private void Awake()
    {
        _dayCounter = GameObject.FindObjectOfType<DayCounter>();
        _meshFilter = GetComponent<MeshFilter>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshCollider = GetComponent<MeshCollider>();
        _transform = GetComponent<Transform>();
        RandomNum(0,360);
        _transform.Rotate(0, _random, 0);
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
        switch (_xp)
        {
            case >= 30://�o���l��30�ȏ�̎���5���x���ɂȂ�
                LevelSwich(4);
                break;
            case >= 20://�o���l��20�ȏ�̎���4���x���ɂȂ�
                LevelSwich(3);
                break;
            case >= 15://�o���l��15�ȏ�̎���3���x���ɂȂ�
                LevelSwich(2);
                break;
            case >= 10://�o���l��10�ȏ�̎���2���x���ɂȂ�
                LevelSwich(1);
                break;
            case >= 5://�o���l��5�ȏ�̎���1���x���ɂȂ�
                LevelSwich(0);
                break;
        }
    }
    void NextDay()//����Method���Ă΂ꂽ�Ƃ��Ƀ����_���Ɍo���l������
    {
        //�{�^���������ꂽ�烉���_���Ȓl��_xp�ɓ����
        int Ran;
        _dayCount++;
        Ran = Random.Range(_rnd[0], _rnd[1]);
        _xp += Ran;
    }


    void LevelSwich(int x)
    {
        if (_levelSwich[x] == false)
        {

            _level += 1;//���x����1�グ��
            _meshFilter.mesh = _mesh[_level - 1];
            _meshRenderer.material = _material[_level - 1];
            _meshCollider.sharedMesh = _mesh[2];
        }
        _levelSwich[x] = true;
    }
    
    void RandomNum(float x,float y)
    {
        _random = Random.Range(x,y);
    }
}
