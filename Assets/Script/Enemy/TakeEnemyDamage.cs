using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeEnemyDamage : MonoBehaviour
{

    [SerializeField] private float _damage_Delay; // задержка между атакой   
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private EnemyDamageData _enemyDamage; // ссылка для взятие свойства урона.                                                   
    [SerializeField] private PlayerDamage _pt;
    private void Start()
    {
        if(_playerHealth == null)
        {
            _playerHealth = FindObjectOfType<PlayerHealth>();
        }
        _enemyDamage = GetComponent<EnemyDamageData>();
    }
    private IEnumerator DamageTime(float a) // Корутина урона
    {
        while (_pt != null)
        {
            yield return new WaitForSeconds(a);
            if (_pt != null)
                _playerHealth.OnChangedCurrentHealth(_enemyDamage.SceneCurrentDamage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerDamage playerDamage))
        {// При входе в триггер - враг получает урон по значею игрока.
            _pt = playerDamage;
            StartCoroutine(DamageTime(_damage_Delay));
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player playerDamage))
        {
            _pt = null;
            StopCoroutine(DamageTime(_damage_Delay));
        }
    }


}
