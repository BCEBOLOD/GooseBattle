using UnityEngine;
using UnityEngine.Events;

public class EnemyDamageData : MonoBehaviour
{
    [SerializeField] private float _baseDamage;
    public float SceneCurrentDamage { get; private set; }// Урон при старте сцены.
    private void Awake()
    {
        SceneCurrentDamage = _baseDamage;
    }



}
