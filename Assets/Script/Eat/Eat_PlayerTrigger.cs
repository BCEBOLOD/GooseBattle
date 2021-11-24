using UnityEngine;
using UnityEngine.Events;
public class Eat_PlayerTrigger : MonoBehaviour
{
    public event UnityAction<float> e_addSatietyToHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Eat_Health eat_health))
        {
            e_addSatietyToHealth?.Invoke(eat_health.Satienty);            
            Destroy(collision.gameObject);
        }
        
    }
}
