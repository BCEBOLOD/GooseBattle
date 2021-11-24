using System.Collections;
using UnityEngine;

public class EnemyIdle : EnemyState
{
    [SerializeField] private Vector2 _basePosition;
    private bool _needBackPosition;

    private void Start()
    {
        _basePosition = transform.position;
        _needBackPosition = false;
    }
    private IEnumerator BackPosigion_Corutine()
    {
        while (Vector2.Distance(transform.position, _basePosition) > 0.2f)
        {
            yield return new WaitForSeconds(0);
            BackToPosition();
        }
        if (Vector2.Distance(transform.position, _basePosition) > 0.2f)
            _needBackPosition = false;
    }

    private void BackToPosition()
    {
        if (_player == null)
            transform.position = Vector2.MoveTowards(transform.position,
                _basePosition, _speed * Time.deltaTime);
    }
    protected override void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            StopCoroutine(Folling_Corutine());
            _player = null;
            _isFolling = false;
            _needBackPosition = true;
            StartCoroutine(BackPosigion_Corutine());

        }
    }

}
