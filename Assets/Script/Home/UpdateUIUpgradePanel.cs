using TMPro;
using UnityEngine;

public class UpdateUIUpgradePanel : MonoBehaviour
{
    [SerializeField] private UpgradePanel _upgradePanel;
    [SerializeField] private UpdateDataInGoosePanel _DataPanelGoose;

    [SerializeField] private TextMeshProUGUI _priceUpgradeHealth;
    [SerializeField] private TextMeshProUGUI _priceUpgradeDamage;

    [SerializeField] private TextMeshProUGUI _valueUpgradeHealth;
    [SerializeField] private TextMeshProUGUI _valueUpgradeDamage;

    private void Start()
    {
        StartData();

    }
    private void StartData()
    {
        _priceUpgradeDamage.text = "����: " + _upgradePanel.PriceDamage.ToString();// ���� ���������
        _valueUpgradeDamage.text = "+ " + _upgradePanel.ValueAddDamage.ToString() + " �����"; // �������� �����
        _priceUpgradeHealth.text = "����: " + _upgradePanel.PriceHealth.ToString(); // ���� ���������
        _valueUpgradeHealth.text = "+ " + _upgradePanel.ValueAddHealth.ToString() + " ��������"; // �������
    }

    private void UpdatePriceAndDescriptionDamage(int pt, float ptt)
    {
        _priceUpgradeDamage.text ="���� : " + pt.ToString();
        _valueUpgradeDamage.text ="+ " +  ptt.ToString()+ " �����";
    }
    private void UpdatePriceAndDescriptionHealth(int pt, float ptt)
    {
        _priceUpgradeHealth.text ="����: " + pt.ToString();
        _valueUpgradeHealth.text ="+ " + ptt.ToString() + " ��������";
    }  

    private void OnEnable()
    {     
        _upgradePanel.e_UpdateDataBeforeBuyHealth += UpdatePriceAndDescriptionHealth;
        _upgradePanel.e_UpdateDataBeforeBuyDamage += UpdatePriceAndDescriptionDamage;
    }
    private void OnDisable()
    {       
        _upgradePanel.e_UpdateDataBeforeBuyHealth -= UpdatePriceAndDescriptionHealth;
        _upgradePanel.e_UpdateDataBeforeBuyDamage -= UpdatePriceAndDescriptionDamage;
    }
}
