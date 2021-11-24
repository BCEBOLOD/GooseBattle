using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class EnemyHealthAndDamageUIBar : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth; // ������� �������� ����� 
    [SerializeField] private EnemyDamageData _enemyDamage; // ���� �����

    [SerializeField] private TextMeshProUGUI _damageText; // ����� �����
    [SerializeField] private TextMeshProUGUI _healthText; // ����� ��
    private void Start()
    {
        _damageText.text = _enemyDamage.SceneCurrentDamage.ToString();
        _healthText.text = _enemyHealth.CurrentHealth.ToString();
    }
    private void OnChangedHealthUiBar(float pt)
    {
        _healthText.text = pt.ToString();
    }
    private void OnEnable()
    {
        _enemyHealth.e_SendHealthForHUD += OnChangedHealthUiBar;
    }
    private void OnDisable()
    {
        _enemyHealth.e_SendHealthForHUD -= OnChangedHealthUiBar;
    }

}
