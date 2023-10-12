using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject[] _posObj;
    Transform _transform;
    int _cameraPosCount = 1;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_cameraPosCount == 1)
            {
                _transform.position = _posObj[1].transform.position;
                _transform.rotation = _posObj[1].transform .rotation;
                _cameraPosCount++;
            }
            else if (_cameraPosCount == 2)
            {
                _transform.position = _posObj[2].transform.position;
                _transform.rotation = _posObj[2].transform.rotation;
                _cameraPosCount++;
            }
            else if (_cameraPosCount == 3)
            {
                _transform.position = _posObj[3].transform.position;
                _transform.rotation = _posObj[3].transform.rotation;
                _cameraPosCount++;
            }
            else if (_cameraPosCount == 4)
            {
                _transform.position = _posObj[0].transform.position;
                _transform.rotation = _posObj[0].transform.rotation;
                _cameraPosCount = 1;
            }

        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            if (_cameraPosCount == 1)
            {
                _transform.position = _posObj[3].transform.position;
                _transform.rotation = _posObj[3].transform.rotation;
                _cameraPosCount = 4;
            }
            else if (_cameraPosCount == 4)
            {
                _transform.position = _posObj[2].transform.position;
                _transform.rotation = _posObj[2].transform.rotation;
                _cameraPosCount--;
            }
            else if (_cameraPosCount == 3)
            {
                _transform.position = _posObj[1].transform.position;
                _transform.rotation = _posObj[1].transform.rotation;
                _cameraPosCount--;
            }
            else if (_cameraPosCount == 2)
            {
                _transform.position = _posObj[0].transform.position;
                _transform.rotation = _posObj[0].transform.rotation;
                _cameraPosCount--;
            }
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
