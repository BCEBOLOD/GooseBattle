using UnityEngine;
using System.Collections.Generic;
public class MissionSystemData : MonoBehaviour
{
    public delegate void d_SendForUI(int a);
    public event d_SendForUI e_SendForUI_MaxCountGooses; // �������� � UI ���������� ������ ����� 
    public event d_SendForUI e_SendForUI_MaxCountMoney; // �������� � UI ���������� ������ �����

    public event d_SendForUI e_SendForUI_CurrentCountGooses; // �������� � UI ���������� ����� ���������
    public event d_SendForUI e_SendForUI_CurrentCountMoney; // �������� � UI ���������� ��������� �����

    public event d_SendForUI e_SendForUI_Final_CountDown; //�������� UI ���������� ������ 

    [SerializeField] private MissionSystemAction_in_OnTrigger _missionAction; //����� ������ �� + ���� /+ �����
    [SerializeField] private TimeOut_UI_Bar _timeOutUIBar; // ��������� �������� �� ��������� �����

    [SerializeField] private int _currentCountGooses;//////// ��������� �����
    [SerializeField] private int _needCountGooses;/////////// ������ ���������� �����

    [SerializeField] private int _currentCountMoney;//////// ��������� �����
    [SerializeField] private int _needCountMoney;/////////// ������ ���������� �����

    [SerializeField] private int _final_CountDown;/////////// ��������� �����

    [SerializeField] private GameObject _uiPanelVictory; // ������ ������
    [SerializeField] private GameObject _uiPanelLoss;// ������ ��������� 



    private void Start()
    {
        e_SendForUI_MaxCountMoney?.Invoke(_needCountMoney); //�������� � UI ���������� ������ �����
        e_SendForUI_MaxCountGooses?.Invoke(_needCountGooses); // �������� � UI ���������� ������ �����
        e_SendForUI_CurrentCountMoney?.Invoke(_currentCountMoney); // �������� ������� ����� � UI
        e_SendForUI_CurrentCountGooses?.Invoke(_currentCountGooses); // �������� ������� ����� � UI
        e_SendForUI_Final_CountDown?.Invoke(_final_CountDown); // ������ ���������� ������
    }
    private void AddMoney() // +1 ������
    {
        _currentCountMoney++;
        e_SendForUI_CurrentCountMoney?.Invoke(_currentCountMoney); //�������� � UI ���������� ��������� �����
        DataForVictory();
    }
    private void AddWildGoose() // +1 ����  
    {
        _currentCountGooses++;
        e_SendForUI_CurrentCountGooses?.Invoke(_currentCountGooses); // �������� � UI ���������� ����� ���������
        DataForVictory();
    }
    private void OnEnable()
    {
        _missionAction.e_SendAddValue_currentCountGooses += AddWildGoose;//  �������� �� +1����
        _missionAction.e_SendAddValue_currentCountMoney += AddMoney;// �������� �� +1 ������
        _timeOutUIBar.e_timeOut += GameLoss; // ����� ������� � �������� �� �����
    }
    private void OnDisable()
    {
        _missionAction.e_SendAddValue_currentCountGooses -= AddWildGoose;
        _missionAction.e_SendAddValue_currentCountMoney -= AddMoney;
        _timeOutUIBar.e_timeOut -= GameLoss;
    }

    private void GameVictory() // ������ 
    {
        Time.timeScale = 0;
        _uiPanelVictory.SetActive(true); //��������� ������ ������ 
        OnDataSave();

        //����� ������ ��� ������� �� ������� ������ �������        
    }
    private void GameLoss() // ��������
    {
        _uiPanelLoss.SetActive(true); // ��������� ������ ��������� 
        Time.timeScale = 0;
    }
    private void OnDataSave()
    {
        
        //���������� ������ �� ���������� ����� � �����
    }
    private void DataForVictory() //�������� ������ �� ������ ���������� ��� ������
    {
        if (_currentCountMoney >= _needCountMoney && _currentCountGooses >= _needCountMoney)
            GameVictory();
    }


}
//TASK
//// ���������� ������� ��� ������ � ����������� ��������� ������ ������.
////�������� � UI +����+������. = OK
///// �������� � UI Max����� �Max����� = ��
///����� �������� �������.���� ������ ���������� ������,�� ����� ������,��� ��������� ������
///+. �����,��� �� ������.���������� ���������� ������ � ���� ������ �������� �����.