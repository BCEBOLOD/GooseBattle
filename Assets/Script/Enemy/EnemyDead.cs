using UnityEngine;
using UnityEngine.Events;

public class EnemyDead : DeadCharacter
{
  //  public delegate void d_AddDamageForPlayer(float Damage); // Добавление урона при смерти флоат
   // public event d_AddDamageForPlayer _e_AddDamageForPlayer; // добавление урона при смерти флоат!


    [SerializeField] private PlayerDamage _playerDamage; // 

    [SerializeField] private EnemyHealth _enemyHealth;    // ссылка на хп Enemy.Подписка на ивент смерти 

    [SerializeField] private float _addValueDamageForPlayer; // Размер добавление урона
    public float AddValueDamagePlayer => _addValueDamageForPlayer;
    private void Awake()
    {
        if(_playerDamage == null)
           _playerDamage = FindObjectOfType<PlayerDamage>();
        if (_enemyHealth == null)
            _enemyHealth = FindObjectOfType<EnemyHealth>();        
    } 

    private void OnDead()
    {
        // _e_AddDamageForPlayer?.Invoke(_addValueDamageForPlayer); //Вызов ивента        
        //Destroy(transform.parent.gameObject);
        _playerDamage.OnAddDamagePlayer(AddValueDamagePlayer);
        transform.DestoyParent();// Метод расширение
        
    }

    protected override void OnEnable()
    {      
        _enemyHealth.e_Dead += OnDead; //Ивент на смерть
    }

    protected override void OnDisable()
    {      
        _enemyHealth.e_Dead -= OnDead; //Ивент на смерть
    }
    private void OnDestroy()
    {
      //  _e_AddDamageForPlayer -= _playerDamage.OnAddDamagePlayer;
        _enemyHealth.e_Dead -= OnDead;
    }
    
}
