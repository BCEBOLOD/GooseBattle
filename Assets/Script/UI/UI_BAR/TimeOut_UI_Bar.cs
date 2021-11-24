using TMPro;
using UnityEngine;
using UnityEngine.Events;
public class TimeOut_UI_Bar : MonoBehaviour
{
    [SerializeField] private MissionSystemData _missionSystemData;
    [SerializeField] private TextMeshProUGUI _timeOutUIText;
    public event UnityAction e_timeOut;

    private float _timeOut;
    private bool _dead;

    private void OnStart_TimeOut_UIBar(int pt)
    {
        _timeOut = (float)pt;
    }
    private void OnEnable()
    {
        _missionSystemData.e_SendForUI_Final_CountDown += OnStart_TimeOut_UIBar;
    }
    private void OnDisable()
    {
        _missionSystemData.e_SendForUI_Final_CountDown -= OnStart_TimeOut_UIBar;
    }
    private void Update()
    {
        _timeOut -= 1 * Time.deltaTime;
        if (_timeOut >= 0)
        {
            _timeOutUIText.text = Mathf.Round(_timeOut).ToString();
        }
        else if (_timeOut <= 0)
        {
            if (!_dead)
            {
                _dead = true;
                e_timeOut?.Invoke();
            }
        }

    }
}
