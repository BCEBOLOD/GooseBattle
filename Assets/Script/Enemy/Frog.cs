using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemy
{
    [SerializeField] private Collider2D _coll2d;
    [Space]
    [SerializeField] private float _jumpUp;
    [SerializeField] private float _forward;
    [Space]
    [SerializeField] private float _leftPoint;
    [SerializeField] private float _rightPoint;
    [Space]
    [SerializeField] private LayerMask _layerMask;
    [Space]
    [SerializeField] private bool _SwitherMove;
    


    protected override void Start()
    {
        base.Start();
        _coll2d = GetComponent<Collider2D>();
    }

    private void Update()
    {
        FrogStateMove();
    }
    private void FrogStateMove()
    {
        if (_animator.GetBool("Jump"))
        {
            if (_rb2d.velocity.y < 0.1f)
            {
                _animator.SetBool("Fall", true);
                _animator.SetBool("Jump", false);
            }
        }
       if (_animator.GetBool("Fall") && _coll2d.IsTouchingLayers(_layerMask))
        {
            _animator.SetBool("Fall", false);
        }
    }

    private void MoveFrog()
    {
        if (_SwitherMove)
        {
            if (transform.position.x > _leftPoint)// если жаба  +5 \\ point = -5
            {
                if (transform.localScale.x != 1) // если размер не в -1(другая сторона)
                {
                    transform.localScale = new Vector2(1, 1);
                }
                if (_coll2d.IsTouchingLayers(_layerMask))
                {
                    _animator.SetBool("Jump", true);
                    _rb2d.velocity = new Vector2(-_forward, _jumpUp);
                }
            }
            else
            {
                _SwitherMove = false;
            }
        }
        else
        {
            if (transform.position.x < _rightPoint)
            {
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector2(-1, 1);
                }
                if (_coll2d.IsTouchingLayers(_layerMask))
                {
                    _rb2d.velocity = new Vector2(  _forward, _jumpUp);
                    _animator.SetBool("Jump", true);
                }
            }
            else
            {
                _SwitherMove = true;
            }
        }
    }

    
}
