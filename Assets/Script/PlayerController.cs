using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 3;//�v���C���[�̃X�s�[�h
    [SerializeField] GameObject _seedObjecct;//��������I�u�W�F�N�g
    [SerializeField]public int _plantCount = 0;//�I�u�W�F�N�g�̐����񐔂��L�^����ϐ�
    public event Action SeedCount;
    Rigidbody _rigidbody = default;
    Vector3 _position;
    bool _isGround = false;//�n�ʂ̃`�F�b�N

    private void Awake()
    {
        SeedCount();
    }
    void Start()
    {
        Physics.gravity = new Vector3(0, -10, 0);
        _rigidbody = GetComponent<Rigidbody>();
        //Debug.Log("���݂̎�̐���" + _plantCount + "�ł�");
    }

    // Update is called once per frame
    void Update()
    {
        _position = new Vector3(transform.position.x, 1, transform.position.z);
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
        if (Input.GetMouseButtonDown(0))//���N���b�N�������ꂽ��I�u�W�F�N�g�𐶐�����֐����Ă�
        {
            PlantObject();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //�G��Ă���I�u�W�F�N�g����Ground�^�O�t���Ă��邩���`�F�b�N����
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
        }
        if (collision.gameObject.tag == "Box")
        {
            Debug.Log("�G�ꂽ");
            CountPlace(10);//_palntCount�Ƀv���X10���Ă���
            Destroy(collision.gameObject);
            TextToString();
        }
    }

    void PlantObject()
    {
        if (_isGround == true)
        {
            //_plantCount��0����̒l�Ȃ�I�u�W�F�N�g�𐶐����ăJ�E���g��1���炷
            if (_plantCount > 0)
            {
                Instantiate(_seedObjecct, _position, Quaternion.identity);
                CountPlace(-1);//_palntCount��-1�������Ă���
                //Debug.Log("�c�萔��" + _plantCount + "�ł�");
                TextToString();
            }
        }

    }

    void TextToString()//_plantCount�̒l���e�L�X�g�ŕ\������
    {
    }

    void CountPlace(int Place)//_plantCount�ɒl�����Z����
    {
        _plantCount += Place;
        SeedCount();
    }
}
