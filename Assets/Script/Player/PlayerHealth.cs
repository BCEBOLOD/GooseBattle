using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    public override event d_Dead e_Dead; // передача в PlayerDead //IHealth.
    public event UnityAction<float, float> e_maxHealthChanged;

    public float CurrentHealth => _base_Health;

    private float _base_Health;
    [SerializeField] private PlayerData _playerData;
   // [SerializeField] private TakePlayerDamage _takePlayerDamage;
    [SerializeField] private Eat_PlayerTrigger _eat_playerTrigger; // Триггер на проверку еды и добавление
    [SerializeField] private float _maxHealthForlvl; // Максимальное хп на уровне
    public float MaxHealtingForLvl => _maxHealthForlvl;

    private void Start()
    {
        if (_playerData == null)
            _playerData = FindObjectOfType<PlayerData>();
        StartSceneHealth();
        OnChangedStateUIBar();
    }      
    public void StartSceneHealth()
    {
        _base_Health = _playerData.HealthData;
        _maxHealthForlvl += _base_Health / 2;

    }


    public void OnChangedCurrentAddHealth(float a)
    {
        if (CurrentHealth < _maxHealthForlvl)
        {
            _base_Health += a;
            if (CurrentHealth > _maxHealthForlvl)
                _base_Health = _maxHealthForlvl;
        }
        OnChangedStateUIBar();
    }
    private void OnChangedMaxAddHealth(float pt)
    {
        _maxHealthForlvl += pt;
        OnChangedStateUIBar();        
    }

    private void OnChangedStateUIBar()
    {
        e_maxHealthChanged?.Invoke(CurrentHealth, _maxHealthForlvl);
    }
    private void OnEnable()
    {
      //  _takePlayerDamage.e_Damage += OnChangedCurrentHealth;
        _eat_playerTrigger.e_addSatietyToHealth += OnChangedMaxAddHealth;
    }
    private void OnDisable()
    {
      //  _takePlayerDamage.e_Damage -= OnChangedCurrentHealth;
        _eat_playerTrigger.e_addSatietyToHealth -= OnChangedMaxAddHealth;
    }
    public void OnChangedCurrentHealth(float a)
    {
        if (CurrentHealth > 0)
        {
            _base_Health -= a;

            if (CurrentHealth <= 0)
            {
                _base_Health = 0;
                e_Dead?.Invoke();
            }
        }
        OnChangedStateUIBar();
    }
}
