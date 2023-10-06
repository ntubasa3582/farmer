using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawnRange : MonoBehaviour
{
    [SerializeField] GameObject _instanceObject;
    MeshCollider _meshCollider;
    DayCounter _dayCounter;
    Vector3 _spawnRenge;
    [SerializeField] int _spawn;
    float[] _random = new float[2];
    private void Awake()
    {
        _dayCounter = GameObject.FindObjectOfType<DayCounter>();
        _meshCollider = GetComponent<MeshCollider>();
        for (int i=0; i < _spawn; i++)
        {
            VectorRandom();
            _spawnRenge = new Vector3(_random[0], 0, _random[1]);
            Instantiate(_instanceObject, _spawnRenge, Quaternion.identity);
        }
    }

    private void OnEnable()
    {
        _dayCounter.DayChange += ObjectSpwan;
    }

    private void OnDisable()
    {
        _dayCounter.DayChange -= ObjectSpwan;
    }

    void ObjectSpwan()
    {
    }


    void VectorRandom()
    {
        for (int i = 0; i < _random.Length; i++)//配列の中に入ってる値を0にする
        {
            _random[i] = 0;
            _random[i] = Random.Range(-4.5f, 4.5f);
        }
    }

    //このスクリプトがアッドコンポーネントされているコライダーの範囲で作物が生成される
    //生成される作物の数はランダム(3～5)の間
    //生成する時XとZがランダムYは固定

}
