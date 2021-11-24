using UnityEngine;

public class Health_UI_Bar : ChangedBar
{

    [SerializeField] private PlayerHealth _playerHealth;
    
    private float _maxHealthForLvl; // Максимальное здоровье на уровне

    private void Awake()
    {
        if (_playerHealth == null)
            _playerHealth = FindObjectOfType<PlayerHealth>();
        _maxHealthForLvl = _playerHealth.MaxHealtingForLvl;
        
        
    }
    //protected override void OnChangedStateUIBar(float Data) //Установка значений на UI  
    //{        
    //    _dataText.text = Data.ToString() + "/" + _maxHealthForLvl.ToString();
    //}
    //public void OnToPutMaxHealth_UIBar(float Data)//Установка максимального хп
    //{
    //    _maxHealthForLvl = Data;

    //}
    private void ChangedUIHealth(float pt,float ptt)
    {
        _dataText.text = pt.ToString() + "/" + ptt.ToString();
    }

    protected override void OnEnable()
    {
       // _playerHealth.e_Health += OnChangedStateUIBar;
        _playerHealth.e_maxHealthChanged += ChangedUIHealth;
    }

    protected override void OnDisable()
    {
       // _playerHealth.e_Health -= OnChangedStateUIBar;
        _playerHealth.e_maxHealthChanged -= ChangedUIHealth;
    }
}
