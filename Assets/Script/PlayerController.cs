using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 3;//�v���C���[�̃X�s�[�h
    [SerializeField] GameObject _seedObjecct;//��������I�u�W�F�N�g
    //���̃��\�b�h���Ă΂ꂽ�Ƃ��ɐ����̃I�u�W�F�N�g�̐����L�^���Ă���e�L�X�g�̒l��ς���
    public event Action SeedCount;
    public event Action FruitsCount;
    Rigidbody _rigidbody = default;
    Vector3 _position;
    bool _isGround = false;//�n�ʂ̃`�F�b�N
    bool _isClick = false;//�C���^�[�o�����`�F�b�N
    bool _longPress = false;//�������ł��邩�̃`�F�b�N
    float _clickTime;//�N���b�N�ł��Ȃ��悤�ɃC���^�[�o�������Ă���
    public int _plantCount = 0;//�I�u�W�F�N�g�̐����񐔂��L�^����ϐ�
    public int _fruitsCount = 0;//Fuits�^�O���t�����I�u�W�F�N�g�ɐG�ꂽ��1�Â�����


    private void Awake()
    {
    }
    void Start()
    {
        SeedCount();
        FruitsCount();
        Physics.gravity = new Vector3(0, -10, 0);
        _rigidbody = GetComponent<Rigidbody>();
        //Debug.Log("���݂̎�̐���" + _plantCount + "�ł�");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_isGround);
        _position = new Vector3(transform.position.x, 0.94f, transform.position.z);
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = Vector3.forward * v + Vector3.right * h;
        // �ړ��̓��͂��Ȃ����͉�]�����Ȃ��B���͂����鎞�͂��̕����ɃL�����N�^�[��������B
        if (dir != Vector3.zero) this.transform.forward = dir;
        _rigidbody.velocity = dir.normalized * _moveSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            transform.position = new Vector3(0, 1.4f, 0);
        }
        if (Input.GetMouseButtonDown(0))//���N���b�N�������ꂽ�璷�����ł���bool��true�ɂ���
        {
            _longPress = true;
        }
        if (Input.GetMouseButtonUp(0))//���N���b�N�������ꂽ�璷�����ł���bool��false�ɂ���
        {
            _longPress = false;
        }
        if (_longPress == true)//���Ԋu�ŃI�u�W�F�N�g�𐶐��ł���悤�ɂ���
        {
            if (_isClick == true)
            {
                _isClick = false;
                PlantObject();
            }
        }
        _clickTime += Time.deltaTime;
        if (_clickTime > 0.5)//�A���ŃN���b�N�o���Ȃ��悤�ɃC���^�[�o�������Ă�
        {
            _isClick = true;
            _clickTime = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //�G��Ă���I�u�W�F�N�g����Ground�^�O�t���Ă��邩���`�F�b�N����
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
        }
        else
        {
            _isGround = false;
        }
        if (collision.gameObject.tag == "Box")
        {
            CountPlace(10);//_palntCount�Ƀv���X10���Ă���
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fruits")
        {
            Debug.Log("�앨�ɐG�ꂽ");
            _fruitsCount++;
            FruitsCount();
            Destroy(other.gameObject);
        }
    }

    void PlantObject()
    {
        if (_isGround == true)
        {
            //_plantCount��0����̒l�Ȃ�I�u�W�F�N�g�𐶐����ăJ�E���g��1���炷
            if (_plantCount > 0)
            {
                Instantiate(_seedObjecct, _position, Quaternion.identity);//�I�u�W�F�N�g�𐶐�����
                CountPlace(-1);//_palntCount��-1�������Ă���
            }
        }

    }

    void CountPlace(int Place)//_plantCount�ɒl�����Z����
    {
        _plantCount += Place;
        SeedCount();
    }
}
