using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HomeSettingScene : MonoBehaviour
{
    [SerializeField] private GameObject _panelUpgrage; // ������ ��������
    [SerializeField] private GameObject _panelButtonUI; // ������ ��������    

    public void OpenMissonScene() // �������� ����� � ��������
    {
        
        SceneManager.LoadScene(2);
    }
    public void OpenUpgrageGoosePanel() // ��������� ������ � ��������� ����
    {
        _panelUpgrage.Active();
        _panelButtonUI.Deactivate();
    }
    public void CloseUpgrageGoosePanel()// ��������� ������ ��������� ����
    {
        _panelUpgrage.Deactivate();
        _panelButtonUI.Active();
    }
   
}

