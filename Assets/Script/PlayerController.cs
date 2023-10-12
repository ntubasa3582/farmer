using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 3;//プレイヤーのスピード
    [SerializeField] GameObject _seedObjecct;//生成するオブジェクト
    [SerializeField]public int _plantCount = 0;//オブジェクトの生成回数を記録する変数
    public event Action SeedCount;
    Rigidbody _rigidbody = default;
    Vector3 _position;
    bool _isGround = false;//地面のチェック

    private void Awake()
    {
        SeedCount();
    }
    void Start()
    {
        Physics.gravity = new Vector3(0, -10, 0);
        _rigidbody = GetComponent<Rigidbody>();
        //Debug.Log("現在の種の数は" + _plantCount + "です");
    }

    // Update is called once per frame
    void Update()
    {
        _position = new Vector3(transform.position.x, 1, transform.position.z);
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
        if (Input.GetMouseButtonDown(0))//左クリックが押されたらオブジェクトを生成する関数を呼ぶ
        {
            PlantObject();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //触れているオブジェクトがにGroundタグ付いているかをチェックする
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
        }
        if (collision.gameObject.tag == "Box")
        {
            Debug.Log("触れた");
            CountPlace(10);//_palntCountにプラス10している
            Destroy(collision.gameObject);
            TextToString();
        }
    }

    void PlantObject()
    {
        if (_isGround == true)
        {
            //_plantCountが0より上の値ならオブジェクトを生成してカウントを1減らす
            if (_plantCount > 0)
            {
                Instantiate(_seedObjecct, _position, Quaternion.identity);
                CountPlace(-1);//_palntCountに-1を代入している
                //Debug.Log("残り数は" + _plantCount + "個です");
                TextToString();
            }
        }

    }

    void TextToString()//_plantCountの値をテキストで表示する
    {
    }

    void CountPlace(int Place)//_plantCountに値を加算する
    {
        _plantCount += Place;
        SeedCount();
    }
}
