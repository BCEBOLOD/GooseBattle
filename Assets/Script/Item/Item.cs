using UnityEngine.Events;
using UnityEngine;


public class Item : MonoBehaviour
{
    [SerializeField] private int _TimeToDestroy;
    [SerializeField] private int _addMoney;  
    [Space]
    private Animator _animator;
    private Collider2D _coll2d;
    private Rigidbody2D _rb2d;
    

    private void Start()
    {        
        _animator = GetComponent<Animator>();
        _coll2d = GetComponent<Collider2D>();
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerContoll _playerContoll))
        {
            _playerContoll.OnCoinChanged(_addMoney);
            Destroy(gameObject);
        }

    }





}
