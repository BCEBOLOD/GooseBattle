using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePlayerDamage : MonoBehaviour
{
    //public override event d_Damage e_Damage; // ����� �� �������� ����� � �������� �����
    //[SerializeField] private float _damage_Delay;
    //[SerializeField] private EnemyDamage _enemyDamage; // ������ ��� ������ �������� �����.                                                   
    //[SerializeField] private EnemyDamage _pt;
    //protected override IEnumerator DamageTime(float a) // �������� �����
    //{

    //    while (_pt != null)
    //    {
    //        yield return new WaitForSeconds(a);
    //        CallDamage();
           
    //    }
    //}
    ////protected override void CallDamage()// �������� ����� 
    ////{
    ////    e_Damage?.Invoke(_enemyDamage.SceneCurrentDamage);
    ////}
    //protected override void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.TryGetComponent(out EnemyDamage enemyDamage))
    //    {// ��� ����� � ������� - ���� �������� ���� �� ������ �����
    //        _pt = enemyDamage;
    //        StartCoroutine(DamageTime(_damage_Delay));
    //    }
    //}
    //protected override void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.TryGetComponent(out EnemyDamage enemyDamage))
    //    {
    //        _pt = null;
    //        StopCoroutine(DamageTime(_damage_Delay));
    //    }
    //}

}
