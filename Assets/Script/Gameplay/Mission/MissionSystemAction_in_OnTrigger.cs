using UnityEngine;

public class MissionSystemAction_in_OnTrigger : MonoBehaviour
{
    public delegate void d_SendDataAddValue();
    public event d_SendDataAddValue e_SendAddValue_currentCountGooses; // Передача в Data количество гусей собранных
    public event d_SendDataAddValue e_SendAddValue_currentCountMoney; // Передача в Data количество собранных гусей  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out MoneyCoin moneyCoin))
        {
            e_SendAddValue_currentCountMoney?.Invoke();
            Destroy(moneyCoin.gameObject);
        }
        if (collision.TryGetComponent(out WildGoose wildGoose))
        {
            e_SendAddValue_currentCountGooses?.Invoke();
            Destroy(wildGoose.gameObject);
        }
    }
}
