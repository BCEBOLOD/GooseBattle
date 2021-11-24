using UnityEngine;
using TMPro;

public class WildGoose_UI_Bar : MonoBehaviour
{
    [SerializeField] private MissionSystemData _missionSystemData;
    [SerializeField] private TextMeshProUGUI _GooseUIText;

    private int _maxCountWildGoose;
    private void OnChanged_Current_UIBar(int pt)
    {
        _GooseUIText.text = pt.ToString() + " / " + _maxCountWildGoose;
    }
    private void OnStart_MaxCountWildGoose(int pt)
    {
        _maxCountWildGoose = pt;
    }
    private void OnEnable()
    {
        _missionSystemData.e_SendForUI_CurrentCountGooses += OnChanged_Current_UIBar;
        _missionSystemData.e_SendForUI_MaxCountGooses += OnStart_MaxCountWildGoose;
    }
    private void OnDisable()
    {
        _missionSystemData.e_SendForUI_CurrentCountGooses -= OnChanged_Current_UIBar;
        _missionSystemData.e_SendForUI_MaxCountGooses -= OnStart_MaxCountWildGoose;
    }
}
