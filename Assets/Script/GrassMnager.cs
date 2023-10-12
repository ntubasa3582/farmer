using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GrassMnager : MonoBehaviour
{
    [SerializeField,Tooltip("変更したいマテリアルをセットする")] Material[] _material;
    [SerializeField,Tooltip("変更したいメッシュをセットする")] Mesh[] _mesh;
    [SerializeField] GameObject[] _cildObjects;
    MeshRenderer _meshRenderer;
    MeshFilter _meshFilter;
    MeshCollider _meshCollider;
    DayCounter _dayCounter;
    Transform _transform;
    Vector3 _cildPos;
    bool[] _levelSwich = new bool[100];//レベルアップのコードを1回だけ実行する
    /// <summary>日にちをカウントする</summary>
    int _dayCount = 0;
    /// <summary>経験値</summary>
    int _xp = 0;
    /// <summary>一定の経験値が手に入ったらレベルを1ずつ上げる</summary>
    int _level = 0;
    /// <summary>オブジェクトが生成される時にランダムな角度にする</summary>
    int _intRandom = default;
    float _floatRandom = default;

    public enum Fruits
    {
        /// <summary>トウモロコシ</summary>
        Corn,
        /// <summary>ナス</summary>
        EggPlant,
        /// <summary>トマト</summary>
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
        _transform.Rotate(0, _floatRandom, 0);//角度をランダムな値にする
        _cildPos = new Vector3(transform.position.x, 1.8f, transform.position.z);
    }

    private void OnEnable()
    {
        _dayCounter.DayChange += NextDay;//デリゲート登録
    }

    private void OnDisable()
    {
        _dayCounter.DayChange -= NextDay;//デリゲート解除
    }

    private void Update()
    {
        switch (_xp)
        {
            case >= 60://経験値が50以上の時に
                Destroy(gameObject);
                break;
            case >= 40://経験値が40以上の時に6レベルになる
                LevelSwich(6);
                break;
            case >= 30://経験値が30以上の時に作物を生成する5レベルになる
                Generate();
                break;
            case >= 20://経験値が20以上の時に4レベルになる
                LevelSwich(4);
                break;
            case >= 15://経験値が15以上の時に3レベルになる
                LevelSwich(3);
                break;
            case >= 10://経験値が10以上の時に2レベルになる
                LevelSwich(2);
                break;
            case >= 5://経験値が5以上の時に1レベルになる
                LevelSwich(1);
                break;
        }
    }
    void NextDay()//このMethodが呼ばれたときにランダムに経験値が入る
    {
        //ボタンが押されたらランダムな値を_xpに入れる
        _dayCount++;
        IntRandom(1, 4);
        _xp += _intRandom;
    }


    void LevelSwich(int x)
    {
        if (_levelSwich[x-1] == false)//一回だけ実行されるようにboolで管理
        {
            _level++;//レベルを1上げる
            _meshFilter.mesh = _mesh[_level - 1];//メッシュを変更する
            _meshRenderer.material = _material[_level - 1];//マテリアルを変更する
            _meshCollider.sharedMesh = _mesh[2];//メッシュコライダーを変更する
        }
        _levelSwich[x-1] = true;
    }

    void Generate()//ランダムな値を配列に代入する
    {
        if (_levelSwich[10] == false)
        {
            IntRandom(0, 3);
            //オブジェクトを生成するときにこのオブジェクトの子オブジェクトとして生成する
            var parent = this.transform;
            GameObject childObject = Instantiate(_cildObjects[_intRandom], _cildPos, Quaternion.identity,parent);
        }
        _levelSwich[10] = true;
    }

    void IntRandom(int x,int y)//ランダムなintの値を代入する
    {
        _intRandom = default;
        _intRandom = Random.Range(x, y);
    }
    void FloatRandom(float x,float y)//ランダムなfloatの値を代入する
    {
        _floatRandom = default;
        _floatRandom = Random.Range(x,y);
    }
}
