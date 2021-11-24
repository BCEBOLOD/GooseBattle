using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointForMove : EnemyState
{
    [SerializeField] private Transform[] _pointForMove; // ��� ����� ��� ��������
    [SerializeField] private int _currentPoint;


    private void Update()
    {
        MovePoint();
        if (Vector2.Distance(transform.position, _pointForMove[_currentPoint].position) < 0.1f)
        {
            _currentPoint++;
            if (_currentPoint == _pointForMove.Length)
                _currentPoint = 0;

           
        }
    }

    private void MovePoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, _pointForMove[_currentPoint].position,
            _speed * Time.deltaTime);
    }

}
