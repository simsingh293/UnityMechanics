using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject _PlayerObj;
    public float _Sensitivity = 10.0f;

    private float _InputX = 0.0f;
    private float _InputY = 0.0f;

    private float _RotationY;
    private float _RotationX;

    Quaternion _NewRotation;
    Quaternion _CurrentRotation;

    public Vector3 _CamereOffset = new Vector3(0.0f, 0.5f, -3.0f);

    // Start is called before the first frame update
    void Start()
    {
        ConnectToPlayer();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void LateUpdate()
    {
        transform.position = _PlayerObj.transform.position + _CamereOffset;
        //transform.forward = _PlayerObj.transform.forward;

        //_PlayerObj.transform.rotation = _CurrentRotation;

        _PlayerObj.transform.eulerAngles = new Vector3(0.0f, _PlayerObj.transform.eulerAngles.y, _PlayerObj.transform.eulerAngles.z);
    }

    void Rotate()
    {
        _InputX = Input.GetAxis("Mouse X");
        _InputY = Input.GetAxis("Mouse Y");

        _RotationY += _InputX * _Sensitivity * Time.deltaTime;
        _RotationX += _InputY * _Sensitivity * Time.deltaTime;

        _RotationX = Mathf.Clamp(_RotationX, -15, 35);
        _RotationY = Mathf.Clamp(_RotationY, -15, 15);

        _NewRotation = Quaternion.Euler(_RotationX, _RotationY, 0.0f);
        transform.rotation = Quaternion.Euler(_RotationX, _RotationY, 0.0f);
        _PlayerObj.transform.rotation = _NewRotation;

        _CurrentRotation = transform.rotation;


    }

    void ConnectToPlayer()
    {
        if (_PlayerObj == null)
        {
            _PlayerObj = GameObject.FindGameObjectWithTag("Player");
            Debug.Log("CAMERA Connected to PLAYER");
        }
        else if (_PlayerObj != null)
        {
            Debug.Log("CAMERA Connected to PLAYER");
        }
        else
        {
            Debug.Log("CAMERA Not Connected to PLAYER");
        }
    }
}
