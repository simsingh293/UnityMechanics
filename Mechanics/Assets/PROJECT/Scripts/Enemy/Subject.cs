using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    EnemyController _Unit;

    public GameObject[] _OtherUnitsGO;
    public List<Observer> _OtherUnitsOB = new List<Observer>();
    public bool _IsAttacked = false;

    public GameObject _Player;

    // Start is called before the first frame update
    void Start()
    {
        _Unit = GetComponent<EnemyController>();
        _OtherUnitsGO = (GameObject.FindGameObjectsWithTag("Enemy"));

        AddObservers();
        
    }

    // Update is called once per frame
    void Update()
    {
        Notify();
    }

    void Notify()
    {
        if (_IsAttacked)
        {
            for (int i = 0; i < _OtherUnitsOB.Count; i++)
            {
                _OtherUnitsOB[i]._TeammateAttacked = true;
                _OtherUnitsOB[i]._SentPlayerObj = _Player;
            }
        }
    }

    void AddObservers()
    {
        for (int i = 0; i < _OtherUnitsGO.Length; i++)
        {
            _OtherUnitsOB.Add(_OtherUnitsGO[i].GetComponent<Observer>());
        }
    }
}
