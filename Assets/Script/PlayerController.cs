using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 3;//プレイヤーのスピード
    [SerializeField] GameObject _seedObjecct;//生成するオブジェクト
    //このメソッドが呼ばれたときに生成のオブジェクトの数を記録しているテキストの値を変える
    public event Action SeedCount;
    public event Action FruitsCount;
    Rigidbody _rigidbody = default;
    Vector3 _position;
    bool _isGround = false;//地面のチェック
    bool _isClick = false;//インターバルをチェック
    bool _longPress = false;//長押しできるかのチェック
    float _clickTime;//クリックできないようにインターバルをつけている
    public int _plantCount = 0;//オブジェクトの生成回数を記録する変数
    public int _fruitsCount = 0;//Fuitsタグが付いたオブジェクトに触れたら1づつ増える


    private void Awake()
    {
    }
    void Start()
    {
        SeedCount();
        FruitsCount();
        Physics.gravity = new Vector3(0, -10, 0);
        _rigidbody = GetComponent<Rigidbody>();
        //Debug.Log("現在の種の数は" + _plantCount + "です");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_isGround);
        _position = new Vector3(transform.position.x, 0.94f, transform.position.z);
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = Vector3.forward * v + Vector3.right * h;
        // 移動の入力がない時は回転させない。入力がある時はその方向にキャラクターを向ける。
        if (dir != Vector3.zero) this.transform.forward = dir;
        _rigidbody.velocity = dir.normalized * _moveSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            transform.position = new Vector3(0, 1.4f, 0);
        }
        if (Input.GetMouseButtonDown(0))//左クリックが押されたら長押しできるboolをtrueにする
        {
            _longPress = true;
        }
        if (Input.GetMouseButtonUp(0))//左クリックが押されたら長押しできるboolをfalseにする
        {
            _longPress = false;
        }
        if (_longPress == true)//一定間隔でオブジェクトを生成できるようにした
        {
            if (_isClick == true)
            {
                _isClick = false;
                PlantObject();
            }
        }
        _clickTime += Time.deltaTime;
        if (_clickTime > 0.5)//連続でクリック出来ないようにインターバルをつけてる
        {
            _isClick = true;
            _clickTime = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //触れているオブジェクトがにGroundタグ付いているかをチェックする
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
            CountPlace(10);//_palntCountにプラス10している
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fruits")
        {
            Debug.Log("作物に触れた");
            _fruitsCount++;
            FruitsCount();
            Destroy(other.gameObject);
        }
    }

    void PlantObject()
    {
        if (_isGround == true)
        {
            //_plantCountが0より上の値ならオブジェクトを生成してカウントを1減らす
            if (_plantCount > 0)
            {
                Instantiate(_seedObjecct, _position, Quaternion.identity);//オブジェクトを生成する
                CountPlace(-1);//_palntCountに-1を代入している
            }
        }

    }

    void CountPlace(int Place)//_plantCountに値を加算する
    {
        _plantCount += Place;
        SeedCount();
    }
}
