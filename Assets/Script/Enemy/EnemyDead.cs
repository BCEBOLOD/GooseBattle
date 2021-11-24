using UnityEngine;
using UnityEngine.Events;

public class EnemyDead : DeadCharacter
{
  //  public delegate void d_AddDamageForPlayer(float Damage); // ���������� ����� ��� ������ �����
   // public event d_AddDamageForPlayer _e_AddDamageForPlayer; // ���������� ����� ��� ������ �����!


    [SerializeField] private PlayerDamage _playerDamage; // 

    [SerializeField] private EnemyHealth _enemyHealth;    // ������ �� �� Enemy.�������� �� ����� ������ 

    [SerializeField] private float _addValueDamageForPlayer; // ������ ���������� �����
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
        // _e_AddDamageForPlayer?.Invoke(_addValueDamageForPlayer); //����� ������        
        //Destroy(transform.parent.gameObject);
        _playerDamage.OnAddDamagePlayer(AddValueDamagePlayer);
        transform.DestoyParent();// ����� ����������
        
    }

    protected override void OnEnable()
    {      
        _enemyHealth.e_Dead += OnDead; //����� �� ������
    }

    protected override void OnDisable()
    {      
        _enemyHealth.e_Dead -= OnDead; //����� �� ������
    }
    private void OnDestroy()
    {
      //  _e_AddDamageForPlayer -= _playerDamage.OnAddDamagePlayer;
        _enemyHealth.e_Dead -= OnDead;
    }
    
}
