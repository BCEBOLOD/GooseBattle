using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : DeadCharacter
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private GameObject _panelLossGame;
  

    private void OnDead()
    {
        Time.timeScale = 0;
        _panelLossGame.SetActive(true);
    }

    protected override void OnDisable()
    {
        _playerHealth.e_Dead -= OnDead;
    }

    protected override void OnEnable()
    {
        _playerHealth.e_Dead += OnDead;
    }
}
