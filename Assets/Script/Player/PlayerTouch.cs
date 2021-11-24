using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouch : MonoBehaviour, IMove
{
    private float _baseSpeed;
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private Joystick _joystick;

    private float _horizontalMove = 0;
    private float _verticalMove = 0;

    private void Start()
    {
        if (_playerData == null)
            _playerData = FindObjectOfType<PlayerData>();
        _baseSpeed = _playerData.SpeedData;
    }
    public void Move()
    {
        _horizontalMove = _joystick.Horizontal * _baseSpeed * Time.deltaTime;
        _verticalMove = _joystick.Vertical * _baseSpeed * Time.deltaTime;
        if (_horizontalMove >= 0.01f)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        else if (_horizontalMove <= -0.01f)
        {
            transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
        }
        transform.Translate(new Vector3(_horizontalMove, _verticalMove, 0));
    }
    private void Update()
    {
        Move();
    }
}


