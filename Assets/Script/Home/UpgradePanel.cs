using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
public class UpgradePanel : MonoBehaviour
{
    public event UnityAction<int, float> e_sendUpgradeHealth; // передача цены,значений +хп
    public event UnityAction<int, float> e_sendUpgradeDamage;// передача цены,значений + урон
    public event UnityAction<int, float> e_UpdateDataBeforeBuyHealth; // обновление текста хп на панели
    public event UnityAction<int, float> e_UpdateDataBeforeBuyDamage; //обновление текста урона на панели
    public event UnityAction e_OnUpdadeStatePanel; // обновление панели показателей

    [SerializeField] private PlayerData _playerData; // ссылка на самого себя - синглтон?Частный случай синглтона?
    [Header("Кнопки улучшения")]
    [SerializeField] private Button _upgradeHealth; // кнопка улучшения хп 
    [SerializeField] private Button _upgradeDamage; // кнопка улучшения урона
    [Header("Кнопки просмотра рекламы")]
    [SerializeField] private Button _AD_Health; //Кнопка просмотра рекламы в бонус +хп
    [SerializeField] private Button _AD_Damage; //Кнопка просмотра рекламы в бонус +урон
    [SerializeField] private Button _AD_Speed;  //Кнопка просмотра рекламы в бонус +скорость
    [Header("Цена улучшений")]
    [SerializeField] private int _priceHealth; // текущая Цена покупки хп
    [SerializeField] private int _priceDamage; // текущая цена покупки урона
    public int PriceHealth => _priceHealth; // Свойство хп
    public int PriceDamage => _priceDamage; // Свойство урона
    [Header("Множитель улучшения цены")]
    [SerializeField] private int _updatePriceHelth; // Сколько будет прибавляться к цене у хп
    [SerializeField] private int _updatePriceDamage; // будет будет прабавляться к цене у урона

    public int UpdatePriceHealth => _updatePriceHelth; // Свойства прибавление цены хп
    public int UpdatePriceDamage => _updatePriceDamage; // Свойства прибалевние цены урона
    [Header("Сколько дает бонусов улучшения")]
    [SerializeField] private float _valueAddHealth; // Сколько дает value за улучшение здоровье
    [SerializeField] private float _valueAddDamage; // Сколько  дает value за улучшение Урона
    public float ValueAddHealth => _valueAddHealth;// Свойство сколько дает Value Здоровье
    public float ValueAddDamage => _valueAddDamage; //Свойтсва сколько дает Value урона.

    private void Start()
    {
        if (_playerData == null)
            _playerData = FindObjectOfType<PlayerData>();
    }
    public void UpgradeHealth()
    {
        if (_playerData.ValidBalance(_priceHealth))
        {
            e_sendUpgradeHealth?.Invoke(_priceHealth, _valueAddHealth); //Передает цену улучшения,+ХП MaxHP
            _priceHealth += _updatePriceHelth;// повышает цену для улучшение
            _valueAddHealth += 2; // повышает value для улучшения
            e_UpdateDataBeforeBuyHealth?.Invoke(PriceHealth, ValueAddHealth);
            e_OnUpdadeStatePanel?.Invoke();
        }
    }
    public void UpgradeDamage()
    {
        if (_playerData.ValidBalance(_priceDamage))
        {
            e_sendUpgradeDamage?.Invoke(_priceDamage, _valueAddDamage);
            _priceDamage += _updatePriceDamage;
            _valueAddDamage += 2;
            e_UpdateDataBeforeBuyDamage?.Invoke(PriceDamage, ValueAddDamage);
            e_OnUpdadeStatePanel?.Invoke();
        }
    }
    private void OnEnable()
    {
        e_sendUpgradeHealth += _playerData.AddHealth;
        e_sendUpgradeDamage += _playerData.AddDamage;
    }
    private void OnDisable()
    {
        e_sendUpgradeHealth -= _playerData.AddHealth;
        e_sendUpgradeDamage -= _playerData.AddDamage;
    }
}
