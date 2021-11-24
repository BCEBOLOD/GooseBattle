using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HomeSettingScene : MonoBehaviour
{
    [SerializeField] private GameObject _panelUpgrage; // Панель открытие
    [SerializeField] private GameObject _panelButtonUI; // панель закрытие    

    public void OpenMissonScene() // Открытие карты с миссиями
    {
        
        SceneManager.LoadScene(2);
    }
    public void OpenUpgrageGoosePanel() // Включение панели С улучшение гуся
    {
        _panelUpgrage.Active();
        _panelButtonUI.Deactivate();
    }
    public void CloseUpgrageGoosePanel()// Выключене панели улучшения гуся
    {
        _panelUpgrage.Deactivate();
        _panelButtonUI.Active();
    }
   
}

