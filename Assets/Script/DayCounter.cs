using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCounter : MonoBehaviour
{
    [SerializeField] float _timer;
    public event Action DayChange;
    float _time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if (_time > _timer)
        {
            Debug.Log("ŽžŠÔ‚¾‚æ");
            _time = 0;
            DayChange();
        }
    }
}
