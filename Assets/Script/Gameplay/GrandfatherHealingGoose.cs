using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class GrandfatherHealingGoose : MonoBehaviour
{
    public event UnityAction<float> e_healingPlayer;

    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private float _valueForHealing;
    [SerializeField] private float _timeForHealingDelay;
    [SerializeField] private float _radiusFowGizmos;
    [SerializeField] private Player _player;
  

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,_radiusFowGizmos );
    }
    private IEnumerator HealingGoose()
    {
        while (_player != null)
        {
            yield return new WaitForSeconds(_timeForHealingDelay);
            if(_player)
            e_healingPlayer?.Invoke(_valueForHealing);

        }
    }
    private void OnEnable()
    {
        e_healingPlayer += _playerHealth.OnChangedCurrentAddHealth;
    }
    private void OnDisable()
    {
        e_healingPlayer -= _playerHealth.OnChangedCurrentAddHealth;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _player = player;
            StartCoroutine(HealingGoose());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _player = null;
            StopCoroutine(HealingGoose());
        }

    }
}
