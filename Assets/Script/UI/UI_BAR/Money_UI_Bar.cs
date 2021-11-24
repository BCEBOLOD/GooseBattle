using TMPro;
using UnityEngine;

public class Money_UI_Bar : MonoBehaviour
{
    [SerializeField] private MissionSystemData _missionSystemData;
    [SerializeField] private TextMeshProUGUI _moneyUIText;

    private int _maxCountMoney;
    private void OnChanged_Current_UIBar(int pt)
    {
        _moneyUIText.text = pt.ToString() + " / " + _maxCountMoney;
    }
    private void OnStart_MaxCountMoney(int pt)
    {
        _maxCountMoney = pt;
    }
    private void OnEnable()
    {
        _missionSystemData.e_SendForUI_CurrentCountMoney += OnChanged_Current_UIBar;
        _missionSystemData.e_SendForUI_MaxCountMoney += OnStart_MaxCountMoney;
    }
    private void OnDisable()
    {
        _missionSystemData.e_SendForUI_CurrentCountMoney -= OnChanged_Current_UIBar;
        _missionSystemData.e_SendForUI_MaxCountMoney -= OnStart_MaxCountMoney;
    }
}
