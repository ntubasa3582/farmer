using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 3;
    Rigidbody _rigidbody = default;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = Vector3.forward * v + Vector3.right * h;
        // 移動の入力がない時は回転させない。入力がある時はその方向にキャラクターを向ける。
        if (dir != Vector3.zero) this.transform.forward = dir;
        _rigidbody.velocity = dir.normalized * _moveSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            transform.position = new Vector3(0, 1, 0);
        }
    }
}
