using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public event UnityAction<float> e_SendHealthForHUD;
    public event UnityAction e_Dead;
    [SerializeField] private float _currentHealth;
  //  [SerializeField] private DamageAbstract _damageAbstract;   
    public float CurrentHealth => _currentHealth;
    private void Awake()
    {
        //if (_damageAbstract == null)
        //    _damageAbstract = GetComponent<DamageAbstract>();
    }
    private void Start()
    {
        
        e_SendHealthForHUD?.Invoke(CurrentHealth);
    }   
    public void SubstracteHealth(float pt)
    {
        _currentHealth -= pt;
        e_SendHealthForHUD?.Invoke(CurrentHealth);
        if (CurrentHealth <= 0)
        {
            e_Dead?.Invoke();
            Destroy(gameObject);
        }

    }
   


}
