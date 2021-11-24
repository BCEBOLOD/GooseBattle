using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_UI_Bar : ChangedBar
{
    [SerializeField] private PlayerDamage _playerDamage;

    private void Start()
    {
        if (_playerDamage == null)
            _playerDamage = FindObjectOfType<PlayerDamage>();

    }
    private  void OnChangedStateUIBar(float Data)
    {

        _dataText.text = Data.ToString();
    }

    protected override void OnEnable()
    {
        _playerDamage.e_SendForUI += OnChangedStateUIBar;
    }

    protected override void OnDisable()
    {
        _playerDamage.e_SendForUI -= OnChangedStateUIBar;
    }
}
// если враг умер + damage;

