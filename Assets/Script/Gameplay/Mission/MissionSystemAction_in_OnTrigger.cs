using UnityEngine;

public class MissionSystemAction_in_OnTrigger : MonoBehaviour
{
    public delegate void d_SendDataAddValue();
    public event d_SendDataAddValue e_SendAddValue_currentCountGooses; // �������� � Data ���������� ����� ���������
    public event d_SendDataAddValue e_SendAddValue_currentCountMoney; // �������� � Data ���������� ��������� �����  

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
