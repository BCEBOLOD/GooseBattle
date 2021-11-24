using TMPro;
using UnityEngine;

public class Speed_UI_Bar : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private TextMeshProUGUI _speedText;

    private void Start()
    {
        if (_playerData == null)
            _playerData = FindObjectOfType<PlayerData>();
        else
            _speedText.text = _playerData.SpeedData.ToString();

        
    }
}
