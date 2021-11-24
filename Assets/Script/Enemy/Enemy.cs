using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Animator _animator;
    protected Rigidbody2D _rb2d;
    [SerializeField] private GameObject _templateMoney;


    protected virtual void  Start()
    {
        _animator = GetComponent<Animator>();
        _rb2d = GetComponent<Rigidbody2D>();
    }

    public void JumpOnEnemy()
    {
        OnSpawnMoney();
        _animator.SetTrigger("Death");
        _rb2d.velocity = Vector2.zero;
        _rb2d.bodyType = RigidbodyType2D.Kinematic;
        GetComponent<Collider2D>().enabled = false;
    }

    private void Death()
    {
        Destroy(gameObject);
    }


    public  void OnSpawnMoney()
    {
        Instantiate(_templateMoney,transform.position, Quaternion.identity);
    }
    
}
