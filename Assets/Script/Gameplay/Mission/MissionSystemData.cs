using UnityEngine;
using System.Collections.Generic;
public class MissionSystemData : MonoBehaviour
{
    public delegate void d_SendForUI(int a);
    public event d_SendForUI e_SendForUI_MaxCountGooses; // Передача в UI количество нужных гусей 
    public event d_SendForUI e_SendForUI_MaxCountMoney; // Передача в UI количество нужных денег

    public event d_SendForUI e_SendForUI_CurrentCountGooses; // Передача в UI количество гусей собранных
    public event d_SendForUI e_SendForUI_CurrentCountMoney; // Передача в UI количество собранных денег

    public event d_SendForUI e_SendForUI_Final_CountDown; //Передача UI финального отчета 

    [SerializeField] private MissionSystemAction_in_OnTrigger _missionAction; //вызов ивента на + гусь /+ денег
    [SerializeField] private TimeOut_UI_Bar _timeOutUIBar; // Получение ивентана на окончание время

    [SerializeField] private int _currentCountGooses;//////// собранных гусей
    [SerializeField] private int _needCountGooses;/////////// Нужное количество гусей

    [SerializeField] private int _currentCountMoney;//////// собранных денег
    [SerializeField] private int _needCountMoney;/////////// Нужное количество денег

    [SerializeField] private int _final_CountDown;/////////// финальный отчет

    [SerializeField] private GameObject _uiPanelVictory; // Панель победы
    [SerializeField] private GameObject _uiPanelLoss;// панель проигрыша 



    private void Start()
    {
        e_SendForUI_MaxCountMoney?.Invoke(_needCountMoney); //Передача в UI количество нужных денег
        e_SendForUI_MaxCountGooses?.Invoke(_needCountGooses); // Передача в UI количество нужных гусей
        e_SendForUI_CurrentCountMoney?.Invoke(_currentCountMoney); // Передача текущих денег в UI
        e_SendForUI_CurrentCountGooses?.Invoke(_currentCountGooses); // Передача текущих гусей в UI
        e_SendForUI_Final_CountDown?.Invoke(_final_CountDown); // Таймер финального отчета
    }
    private void AddMoney() // +1 монета
    {
        _currentCountMoney++;
        e_SendForUI_CurrentCountMoney?.Invoke(_currentCountMoney); //Передача в UI количество собранных денег
        DataForVictory();
    }
    private void AddWildGoose() // +1 гусь  
    {
        _currentCountGooses++;
        e_SendForUI_CurrentCountGooses?.Invoke(_currentCountGooses); // Передача в UI количество гусей собранных
        DataForVictory();
    }
    private void OnEnable()
    {
        _missionAction.e_SendAddValue_currentCountGooses += AddWildGoose;//  подписка на +1гуся
        _missionAction.e_SendAddValue_currentCountMoney += AddMoney;// подписка на +1 монету
        _timeOutUIBar.e_timeOut += GameLoss; // Время выходит и подписка на эвент
    }
    private void OnDisable()
    {
        _missionAction.e_SendAddValue_currentCountGooses -= AddWildGoose;
        _missionAction.e_SendAddValue_currentCountMoney -= AddMoney;
        _timeOutUIBar.e_timeOut -= GameLoss;
    }

    private void GameVictory() // Победа 
    {
        Time.timeScale = 0;
        _uiPanelVictory.SetActive(true); //Включение панели победы 
        OnDataSave();

        //Вывод панели где указано за сколько прошел уровень        
    }
    private void GameLoss() // Проигрыш
    {
        _uiPanelLoss.SetActive(true); // Включение панели поражения 
        Time.timeScale = 0;
    }
    private void OnDataSave()
    {
        
        //отправляет данные на сохранения Денег и Гусей
    }
    private void DataForVictory() //Проверка данных на нужное количество для победы
    {
        if (_currentCountMoney >= _needCountMoney && _currentCountGooses >= _needCountMoney)
            GameVictory();
    }


}
//TASK
//// Замедление времени при победе с последующим открытием панели победы.
////Передача в UI +гуся+монету. = OK
///// Передача в UI MaxГусей иMaxденег = ОК
///нужна проверка текущее.Если нужное количество собрал,то вывод панели,что произошла победа
///+. Вывод,что всё собрал.Происходит сохранение данных в файл общего хранения денег.