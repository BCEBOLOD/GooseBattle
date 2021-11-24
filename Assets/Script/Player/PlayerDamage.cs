using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private float _baseDamage; // Для старта.Для улучшения в панели апгрейда
    public float SceneCurrentDamage => _baseDamage;// Урон при старте сцены.

    [SerializeField] private PlayerData _playerData;
    [SerializeField] private float _delayAttack;
    public float DelayAttack => _delayAttack;


    public delegate void d_SendForUI(float a);
    public event d_SendForUI e_SendForUI; // Передача в UI

    private void Awake()
    {
        if (_playerData == null)
            _playerData = FindObjectOfType<PlayerData>();
    }

    private void Start()
    {
       
        _baseDamage = _playerData.DamageData;
       // SceneCurrentDamage = _baseDamage;
        OnChangedStateUIBar();
    }
    public void OnAddDamagePlayer(float pt)
    {
        //SceneCurrentDamage += pt;
        _baseDamage += pt;
        OnChangedStateUIBar();
    }
    private void OnChangedStateUIBar()
    {
        e_SendForUI?.Invoke(SceneCurrentDamage); // Передача  урона на панель UI
    }
   

  

}

