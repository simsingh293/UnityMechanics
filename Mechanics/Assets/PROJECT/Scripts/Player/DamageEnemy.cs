using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    public GameObject _Player;
    // Start is called before the first frame update
    void Start()
    {
        _Player = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Subject _Unit = collision.gameObject.GetComponent<Subject>();
            _Unit._Player = _Player;
            _Unit._IsAttacked = true;
        }
    }
}
