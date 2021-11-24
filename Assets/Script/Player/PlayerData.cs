using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private int _balance;
    [SerializeField] private float _healthData;
    [SerializeField] private float _damageData;
    [SerializeField] private float _speedData;

    public static PlayerData playerData;

    public int Balance => _balance;
    public float HealthData => _healthData;
    public float DamageData => _damageData;
    public float SpeedData => _speedData;

    private void Awake()
    {
        if (playerData == null)
            playerData = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
    public void AddDamage(int ptt, float pt)
    {
        SubstraceBalanceBeforeBuy(ptt);
        _damageData += pt;
    }
    public void AddHealth(int ptt, float pt)
    {
        SubstraceBalanceBeforeBuy(ptt);
        _healthData += pt;
    }
    private void SubstraceBalanceBeforeBuy(int price)
    {
        _balance -= price;
    }
    public bool ValidBalance(int price)
    {
        if (Balance >= price)
            return true;
        else
            return false;
    }

}
