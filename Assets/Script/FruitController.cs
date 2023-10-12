using UnityEngine;

public class FruitController : MonoBehaviour
{
    Transform _transform;
    void Start()
    {
        _transform = GetComponent<Transform>();
        _transform.Rotate(-90, 0, 0);
    }


}
