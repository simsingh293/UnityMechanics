using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;

    public float _MoveSpeed = 10.0f;
    private float _InputX = 0.0f;
    private float _InputZ = 0.0f;
    private Vector3 _MoveForce;
    private Quaternion _RotationForce;
    public float _RotationSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        ConnectRigidbody();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    // Mechanic Setup
    void Movement()
    {
        _InputZ = Input.GetAxis("Vertical");
        _InputX = Input.GetAxis("Horizontal");

        
        _MoveForce = new Vector3(_InputX, 0.0f, _InputZ);
        //_MoveForce = Camera.main.transform.rotation * _MoveForce;
        _MoveForce.y = 0.0f;

        _rb.MovePosition(transform.position + (_MoveForce * _MoveSpeed * Time.deltaTime));
        
    }

    void Rotation()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + _RotationSpeed, transform.rotation.eulerAngles.z);
        //}
    }

    // Component Setup
    void ConnectRigidbody()
    {
        if(_rb == null)
        {
            _rb = GetComponent<Rigidbody>();
            Debug.Log("PLAYER RigidBody Connected");
        }
        else
        {
            Debug.Log("PLAYER RigidBody not connected.");
        }
    }
}
