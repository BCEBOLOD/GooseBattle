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
        _priceUpgradeDamage.text = "Цена: " + _upgradePanel.PriceDamage.ToString();// цена улучшения
        _valueUpgradeDamage.text = "+ " + _upgradePanel.ValueAddDamage.ToString() + " Урона"; // значение урона
        _priceUpgradeHealth.text = "Цена: " + _upgradePanel.PriceHealth.ToString(); // цена улучшения
        _valueUpgradeHealth.text = "+ " + _upgradePanel.ValueAddHealth.ToString() + " Здоровье"; // значени
    }

    private void UpdatePriceAndDescriptionDamage(int pt, float ptt)
    {
        _priceUpgradeDamage.text ="Цена : " + pt.ToString();
        _valueUpgradeDamage.text ="+ " +  ptt.ToString()+ " Урона";
    }
    private void UpdatePriceAndDescriptionHealth(int pt, float ptt)
    {
        _priceUpgradeHealth.text ="Цена: " + pt.ToString();
        _valueUpgradeHealth.text ="+ " + ptt.ToString() + " Здоровье";
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
