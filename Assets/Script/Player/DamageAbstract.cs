using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class DamageAbstract : MonoBehaviour, IDamage
{
    [SerializeField] private PlayerDamage _playerDamage; // Урон игрока брать по ссылке
    [SerializeField] private List<EnemyHealth> _enemyHealth; // Коллекция всех объектов с NewEnemyHealth;  
    [SerializeField] private EnemyHealth ptObject;// объект для нанесение урона.

    [SerializeField] private bool CorounineStarting; // Проверка стартовала ли корутина.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyHealth enemyHealth))
        {
            _enemyHealth.Add(enemyHealth);
            if (_enemyHealth.Count > 0 && CorounineStarting == false)
            {
                StartCoroutine(DamageEnemy());
            }
        }
    }
    private IEnumerator DamageEnemy()
    {
        CorounineStarting = true;
        while (_enemyHealth.Count > 0)
        {
            yield return new WaitForSeconds(_playerDamage.DelayAttack);
            
            if (_enemyHealth.Count > 0)
                ptObject = _enemyHealth[0];
            if (ptObject != null)
            {
                ptObject.SubstracteHealth(_playerDamage.SceneCurrentDamage);    
            }
            else
                CorounineStarting = false;
        }
        CorounineStarting = false;
        ResetCoriunineStarting();
    }
    private void ResetCoriunineStarting()
    {
        if (_enemyHealth.Count == 0)
            CorounineStarting = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyHealth enemyHealth))
        {
            if (_enemyHealth.Count == 0)
            {
                StopCoroutine(DamageEnemy());
            }
            _enemyHealth.Remove(enemyHealth);
            ResetCoriunineStarting();
        }
    }
    private void Start()
    {
        _enemyHealth = new List<EnemyHealth>();
        if (_playerDamage == null)
            _playerDamage = FindObjectOfType<PlayerDamage>();
    }
    public void ActionIDamage()
    {

    }
}
