using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollingEnemyAPlayer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeFolling;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _player = player;
            StartCoroutine(Folling_Corutine(_timeFolling));
        }
    }
    private void Update()
    {
        print(transform.position.x);
        print(_player.transform.position.x);
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            StopCoroutine(Folling_Corutine(_timeFolling));
            _player = null;
        }
    }
    private IEnumerator Folling_Corutine(float TimeFolling)
    {
        while (_player != null)
        {
            yield return new WaitForSeconds(TimeFolling);
            Folling();
        }
    }
    private void Folling()
    {
        if (_player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position,
                _speed * Time.deltaTime);
           
        }
    }
}
