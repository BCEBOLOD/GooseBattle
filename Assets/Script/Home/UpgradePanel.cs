using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
public class UpgradePanel : MonoBehaviour
{
    public event UnityAction<int, float> e_sendUpgradeHealth; // �������� ����,�������� +��
    public event UnityAction<int, float> e_sendUpgradeDamage;// �������� ����,�������� + ����
    public event UnityAction<int, float> e_UpdateDataBeforeBuyHealth; // ���������� ������ �� �� ������
    public event UnityAction<int, float> e_UpdateDataBeforeBuyDamage; //���������� ������ ����� �� ������
    public event UnityAction e_OnUpdadeStatePanel; // ���������� ������ �����������

    [SerializeField] private PlayerData _playerData; // ������ �� ������ ���� - ��������?������� ������ ���������?
    [Header("������ ���������")]
    [SerializeField] private Button _upgradeHealth; // ������ ��������� �� 
    [SerializeField] private Button _upgradeDamage; // ������ ��������� �����
    [Header("������ ��������� �������")]
    [SerializeField] private Button _AD_Health; //������ ��������� ������� � ����� +��
    [SerializeField] private Button _AD_Damage; //������ ��������� ������� � ����� +����
    [SerializeField] private Button _AD_Speed;  //������ ��������� ������� � ����� +��������
    [Header("���� ���������")]
    [SerializeField] private int _priceHealth; // ������� ���� ������� ��
    [SerializeField] private int _priceDamage; // ������� ���� ������� �����
    public int PriceHealth => _priceHealth; // �������� ��
    public int PriceDamage => _priceDamage; // �������� �����
    [Header("��������� ��������� ����")]
    [SerializeField] private int _updatePriceHelth; // ������� ����� ������������ � ���� � ��
    [SerializeField] private int _updatePriceDamage; // ����� ����� ������������ � ���� � �����

    public int UpdatePriceHealth => _updatePriceHelth; // �������� ����������� ���� ��
    public int UpdatePriceDamage => _updatePriceDamage; // �������� ����������� ���� �����
    [Header("������� ���� ������� ���������")]
    [SerializeField] private float _valueAddHealth; // ������� ���� value �� ��������� ��������
    [SerializeField] private float _valueAddDamage; // �������  ���� value �� ��������� �����
    public float ValueAddHealth => _valueAddHealth;// �������� ������� ���� Value ��������
    public float ValueAddDamage => _valueAddDamage; //�������� ������� ���� Value �����.

    private void Start()
    {
        if (_playerData == null)
            _playerData = FindObjectOfType<PlayerData>();
    }
    public void UpgradeHealth()
    {
        if (_playerData.ValidBalance(_priceHealth))
        {
            e_sendUpgradeHealth?.Invoke(_priceHealth, _valueAddHealth); //�������� ���� ���������,+�� MaxHP
            _priceHealth += _updatePriceHelth;// �������� ���� ��� ���������
            _valueAddHealth += 2; // �������� value ��� ���������
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
