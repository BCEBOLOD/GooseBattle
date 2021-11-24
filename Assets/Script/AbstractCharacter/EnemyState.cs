using UnityEngine;
using System.Collections;
public class EnemyState : MonoBehaviour
{
    [SerializeField] protected Player _player;

    [SerializeField] protected bool _isFolling;    
    [SerializeField] protected float _speed;    

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _player = player;
            StartCoroutine(Folling_Corutine());           
            _isFolling = true;
        }
    }
    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            StopCoroutine(Folling_Corutine());
            _player = null;
            _isFolling = false;

        }
    }
    protected IEnumerator Folling_Corutine()
    {
        while (_player != null)
        {
            yield return new WaitForSeconds(0);
            Folling();
        }
    }
    protected void Folling()
    {
        if (_player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                _player.transform.position, _speed * Time.deltaTime);
            if (transform.position.x < _player.transform.position.x)
                transform.localScale = new Vector3(1, 1, 1);
            else if (transform.position.x > _player.transform.position.x)
                transform.localScale = new Vector3(-1, 1, 1);
        }
       
       
    }

 

}

