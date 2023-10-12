using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GrassMnager : MonoBehaviour
{
    [Header("�����͈̔͂̍Œ�l��0�ōō��l��1")]
    [SerializeField] int[] _rnd = null;
    [SerializeField,Tooltip("�ύX�������}�e���A�����Z�b�g����")] Material[] _material;
    [SerializeField,Tooltip("�ύX���������b�V�����Z�b�g����")] Mesh[] _mesh;
    MeshRenderer _meshRenderer;
    MeshFilter _meshFilter;
    MeshCollider _meshCollider;
    DayCounter _dayCounter;
    Transform _transform;
    bool[] _levelSwich = new bool[100];//���x���A�b�v�̃R�[�h��1�񂾂����s����
    /// <summary>���ɂ����J�E���g����</summary>
    int _dayCount = 0;
    /// <summary>�o���l</summary>
    int _xp = 0;
    /// <summary>���̌o���l����ɓ������烌�x����1���グ��</summary>
    int _level = 0;
    /// <summary>�I�u�W�F�N�g����������鎞�Ƀ����_���Ȋp�x�ɂ���</summary>
    float _rotRandom;
    private void Awake()
    {
        _dayCounter = GameObject.FindObjectOfType<DayCounter>();
        _meshFilter = GetComponent<MeshFilter>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshCollider = GetComponent<MeshCollider>();
        _transform = GetComponent<Transform>();
        RandomNum(0,360);
        _transform.Rotate(0, _rotRandom, 0);
        for (int i = 0; i < _meshRenderer.materials.Length; i++)
        {
            _meshRenderer.materials[i] = GetComponent<Material>();
        }
    }

    private void OnEnable()
    {
        _dayCounter.DayChange += NextDay;//�f���Q�[�g�o�^
    }

    private void OnDisable()
    {
        _dayCounter.DayChange -= NextDay;//�f���Q�[�g����
    }

    private void Update()
    {
        switch (_xp)
        {
            case >= 50:
                Destroy(gameObject);
                break;
            case >= 30://�o���l��30�ȏ�̎���5���x���ɂȂ�
                LevelSwich(5);
                break;
            case >= 20://�o���l��20�ȏ�̎���4���x���ɂȂ�
                LevelSwich(4);
                break;
            case >= 15://�o���l��15�ȏ�̎���3���x���ɂȂ�
                LevelSwich(3);
                break;
            case >= 10://�o���l��10�ȏ�̎���2���x���ɂȂ�
                LevelSwich(2);
                break;
            case >= 5://�o���l��5�ȏ�̎���1���x���ɂȂ�
                LevelSwich(1);
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
        if (_levelSwich[x-1] == false)
        {

            _level++;//���x����1�グ��
            _meshFilter.mesh = _mesh[_level - 1];//���b�V����ύX����
            _meshRenderer.material = _material[_level - 1];//�}�e���A����ύX����
            _meshCollider.sharedMesh = _mesh[2];//���b�V���R���C�_�[��ύX����
        }
        _levelSwich[x-1] = true;
    }
    
    void RandomNum(float x,float y)
    {
        _rotRandom = Random.Range(x,y);
    }
}
