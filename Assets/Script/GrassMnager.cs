using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GrassMnager : MonoBehaviour
{
    [SerializeField,Tooltip("�ύX�������}�e���A�����Z�b�g����")] Material[] _material;
    [SerializeField,Tooltip("�ύX���������b�V�����Z�b�g����")] Mesh[] _mesh;
    [SerializeField] GameObject[] _cildObjects;
    MeshRenderer _meshRenderer;
    MeshFilter _meshFilter;
    MeshCollider _meshCollider;
    DayCounter _dayCounter;
    Transform _transform;
    Vector3 _cildPos;
    bool[] _levelSwich = new bool[100];//���x���A�b�v�̃R�[�h��1�񂾂����s����
    /// <summary>���ɂ����J�E���g����</summary>
    int _dayCount = 0;
    /// <summary>�o���l</summary>
    int _xp = 0;
    /// <summary>���̌o���l����ɓ������烌�x����1���グ��</summary>
    int _level = 0;
    /// <summary>�I�u�W�F�N�g����������鎞�Ƀ����_���Ȋp�x�ɂ���</summary>
    int _intRandom = default;
    float _floatRandom = default;

    public enum Fruits
    {
        /// <summary>�g�E�����R�V</summary>
        Corn,
        /// <summary>�i�X</summary>
        EggPlant,
        /// <summary>�g�}�g</summary>
        Tomato,
    }

    public enum LevelGrass
    {
        Level0,
        Level1,
        Level2,
        Level3,
        Level4,
        LEvel5,
        Level6,
        Level7,
        Level8,
    }

    private void Awake()
    {
        _dayCounter = GameObject.FindObjectOfType<DayCounter>();
        _meshFilter = GetComponent<MeshFilter>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshCollider = GetComponent<MeshCollider>();
        _transform = GetComponent<Transform>();
        FloatRandom(0, 360);
        _transform.Rotate(0, _floatRandom, 0);//�p�x�������_���Ȓl�ɂ���
        _cildPos = new Vector3(transform.position.x, 1.8f, transform.position.z);
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
            case >= 60://�o���l��50�ȏ�̎���
                Destroy(gameObject);
                break;
            case >= 40://�o���l��40�ȏ�̎���6���x���ɂȂ�
                LevelSwich(6);
                break;
            case >= 30://�o���l��30�ȏ�̎��ɍ앨�𐶐�����5���x���ɂȂ�
                Generate();
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
        _dayCount++;
        IntRandom(1, 4);
        _xp += _intRandom;
    }


    void LevelSwich(int x)
    {
        if (_levelSwich[x-1] == false)//��񂾂����s�����悤��bool�ŊǗ�
        {
            _level++;//���x����1�グ��
            _meshFilter.mesh = _mesh[_level - 1];//���b�V����ύX����
            _meshRenderer.material = _material[_level - 1];//�}�e���A����ύX����
            _meshCollider.sharedMesh = _mesh[2];//���b�V���R���C�_�[��ύX����
        }
        _levelSwich[x-1] = true;
    }

    void Generate()//�����_���Ȓl��z��ɑ������
    {
        if (_levelSwich[10] == false)
        {
            IntRandom(0, 3);
            //�I�u�W�F�N�g�𐶐�����Ƃ��ɂ��̃I�u�W�F�N�g�̎q�I�u�W�F�N�g�Ƃ��Đ�������
            var parent = this.transform;
            GameObject childObject = Instantiate(_cildObjects[_intRandom], _cildPos, Quaternion.identity,parent);
        }
        _levelSwich[10] = true;
    }

    void IntRandom(int x,int y)//�����_����int�̒l��������
    {
        _intRandom = default;
        _intRandom = Random.Range(x, y);
    }
    void FloatRandom(float x,float y)//�����_����float�̒l��������
    {
        _floatRandom = default;
        _floatRandom = Random.Range(x,y);
    }
}
