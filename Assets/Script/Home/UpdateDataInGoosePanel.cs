using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UpdateDataInGoosePanel : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private UpgradePanel _upgradePanel;

    [SerializeField] private TextMeshProUGUI _damage;
    [SerializeField] private TextMeshProUGUI _health;
    [SerializeField] private TextMeshProUGUI _speed;
    [SerializeField] private TextMeshProUGUI _balancePanel;
    [SerializeField] private TextMeshProUGUI _balanceHUD;

    private void Start()
    {
        if (_playerData == null)
            _playerData = FindObjectOfType<PlayerData>();
        UpdateDataGoose();
    }

    private void UpdateDataGoose()
    {
        _damage.text = _playerData.DamageData.ToString();
        _health.text = _playerData.HealthData.ToString();
        _speed.text = _playerData.SpeedData.ToString();
        _balancePanel.text = _playerData.Balance.ToString();
        _balanceHUD.text = _balancePanel.text;
     }
    private void OnEnable()
    {
        _upgradePanel.e_OnUpdadeStatePanel += UpdateDataGoose;
    }
    private void OnDisable()
    {
        _upgradePanel.e_OnUpdadeStatePanel -= UpdateDataGoose;
    }
}
