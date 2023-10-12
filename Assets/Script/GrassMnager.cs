using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GrassMnager : MonoBehaviour
{
    [Header("乱数の範囲の最低値が0で最高値が1")]
    [SerializeField] int[] _rnd = null;
    [SerializeField,Tooltip("変更したいマテリアルをセットする")] Material[] _material;
    [SerializeField,Tooltip("変更したいメッシュをセットする")] Mesh[] _mesh;
    MeshRenderer _meshRenderer;
    MeshFilter _meshFilter;
    MeshCollider _meshCollider;
    DayCounter _dayCounter;
    Transform _transform;
    bool[] _levelSwich = new bool[100];//レベルアップのコードを1回だけ実行する
    /// <summary>日にちをカウントする</summary>
    int _dayCount = 0;
    /// <summary>経験値</summary>
    int _xp = 0;
    /// <summary>一定の経験値が手に入ったらレベルを1ずつ上げる</summary>
    int _level = 0;
    /// <summary>オブジェクトが生成される時にランダムな角度にする</summary>
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
            case >= 50:
                Destroy(gameObject);
                break;
            case >= 30://経験値が30以上の時に5レベルになる
                LevelSwich(5);
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
        int Ran;
        _dayCount++;
        Ran = Random.Range(_rnd[0], _rnd[1]);
        _xp += Ran;
    }


    void LevelSwich(int x)
    {
        if (_levelSwich[x-1] == false)
        {

            _level++;//レベルを1上げる
            _meshFilter.mesh = _mesh[_level - 1];//メッシュを変更する
            _meshRenderer.material = _material[_level - 1];//マテリアルを変更する
            _meshCollider.sharedMesh = _mesh[2];//メッシュコライダーを変更する
        }
        _levelSwich[x-1] = true;
    }
    
    void RandomNum(float x,float y)
    {
        _rotRandom = Random.Range(x,y);
    }
}
