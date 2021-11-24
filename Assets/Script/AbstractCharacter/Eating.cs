using UnityEngine;
using UnityEngine.Events;
public abstract class Eating : MonoBehaviour
{
    public event UnityAction<float> e_addSatietyToHealth;
    [SerializeField] private float _satiety;
    public float Satienty => _satiety;   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Eat_Health eat_health))
        {
            e_addSatietyToHealth?.Invoke(eat_health.Satienty);
            
        }        
    }

}
