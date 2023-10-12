using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]GameObject[] _posObj;
    Transform _transform;
    int _cameraPosCount = 1;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (_cameraPosCount == 1)
            {
                _transform.position = _posObj[1].transform.position;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _transform.position = _posObj[3].transform.position;
        }
    }

    //äeÉJÉÅÉâÇÃäpìx
    //cm1 0 5 -10
    //15 0
    //cm2 -10 5 0
    //15 90
    //cm3 0 5 10
    //15 180
    //cm4 10 5 0
    //15 270
}
