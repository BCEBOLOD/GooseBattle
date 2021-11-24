using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private GameObject _obtpt;
    private Ichar _ichar;

    private void Start()
    {
        _ichar = _obtpt.GetComponent<Ichar>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
            _ichar.Action();
    }
}
