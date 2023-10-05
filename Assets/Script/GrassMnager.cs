using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassMnager : MonoBehaviour
{
    [Header("乱数の範囲の最低値が0で最高値が1")]
    [SerializeField] int[] _rnd = null; //
    [SerializeField] Material[] _material;//変更したいマテリアルをセットする
    [SerializeField] Mesh[] _mesh;//変更したいメッシュをセットする
    MeshRenderer _meshRenderer;
    MeshFilter _meshFilter;
    DayCounter _dayCounter;
    bool[] _levelSwich = new bool[3];//レベルアップのコードを1回だけ実行する
    int _dayCount = 0;//日にちをカウントする
    int _xp = 0;//経験値
    int _level = 0;//一定の経験値が手に入ったらレベルを1ずつ上げる
    private void Awake()
    {
        _dayCounter = GameObject.FindObjectOfType<DayCounter>();
        _meshFilter = GetComponent<MeshFilter>();
        _meshRenderer = GetComponent<MeshRenderer>();
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
        if (_xp >= 5 && _xp < 10)//5レベル以上になった時にレベルを１に上げる
        {
            if (_levelSwich[0] == false)
            {
                LevelUp();
                _levelSwich[0] = true;
            }
        }
        else if (_xp >= 10 && _xp < 15)//10レベル以上になった時にレベルを2に上げる
        {
            if (_levelSwich[1] == false)
            {
                LevelUp();
                _levelSwich[1] = true;
            }
        }
        else if (_xp >= 15 && _xp < 20)//15レベル以上になった時にレベルを3に上げる
        {
            if (_levelSwich[2] == false)
            {
                LevelUp();
                _levelSwich[2] = true;
            }
        }
    }
    public void NextDay()
    {
        //ボタンが押されたらランダムな値を_xpに入れる
        int Ran;
        _dayCount++;
        Debug.Log(_dayCount + "日目");
        Ran = Random.Range(_rnd[0], _rnd[1]);
        _xp += Ran;
    }

    public void LevelUp()
    {
        //OnMat();//レベルが上がったときにMethodを呼び出す
        _level += 1;//レベルを1上げる
        Debug.Log("現在" + _level + "レベルです");
        MaterialChange();
    }
    void MaterialChange()
    {
        //レベルが上がったときにメッシュとマテリアルを変更する
        switch (_level)
        {
            case 1:
                _meshFilter.mesh = _mesh[0];
                _meshRenderer.material = _material[0];
                break;
            case 2:
                _meshFilter.mesh = _mesh[1];
                _meshRenderer.material = _material[1];
                break;
            case 3:
                _meshFilter.mesh = _mesh[2];
                _meshRenderer.material = _material[2];
                break;
        }
    }
}
