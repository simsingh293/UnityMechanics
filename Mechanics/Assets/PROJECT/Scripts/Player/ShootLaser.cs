using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootLaser : MonoBehaviour
{
    RaycastHit _hit;
    LineRenderer _LineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _LineRenderer = GetComponent<LineRenderer>();
        _LineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        _LineRenderer.transform.position = transform.position;
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _LineRenderer.enabled = true;
            Ray ray = new Ray(transform.position, transform.forward);

            _LineRenderer.SetPosition(0, ray.origin);

            if(Physics.Raycast(ray, out _hit, 5))
            {
                _LineRenderer.SetPosition(1, _hit.point);
            }

            Debug.Log("Hit");

            
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            _LineRenderer.enabled = false;
        }
    }
}
