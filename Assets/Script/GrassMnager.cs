using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GrassMnager : MonoBehaviour
{
    [Header("乱数の範囲の最低値が0で最高値が1")]
    [SerializeField] int[] _rnd = null; //
    [SerializeField] Material[] _material;//変更したいマテリアルをセットする
    [SerializeField] Mesh[] _mesh;//変更したいメッシュをセットする
    MeshRenderer _meshRenderer;
    MeshFilter _meshFilter;
    MeshCollider _meshCollider;
    DayCounter _dayCounter;
    Transform _transform;
    bool[] _levelSwich = new bool[100];//レベルアップのコードを1回だけ実行する
    int _dayCount = 0;//日にちをカウントする
    int _xp = 0;//経験値
    int _level = 0;//一定の経験値が手に入ったらレベルを1ずつ上げる
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
            case >= 30://経験値が30以上の時に5レベルになる
                LevelSwich(4);
                break;
            case >= 20://経験値が20以上の時に4レベルになる
                LevelSwich(3);
                break;
            case >= 15://経験値が15以上の時に3レベルになる
                LevelSwich(2);
                break;
            case >= 10://経験値が10以上の時に2レベルになる
                LevelSwich(1);
                break;
            case >= 5://経験値が5以上の時に1レベルになる
                LevelSwich(0);
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
        if (_levelSwich[x] == false)
        {

            _level += 1;//レベルを1上げる
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
