using UnityEngine;
using UnityEngine.SceneManagement;
public class UI_GameVictoryPanel : MonoBehaviour
{ 
    public void MultiAward()
    {

    }
    public void ToHomeMaps()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void MapsMission()
    {
        SceneManager.LoadScene(1); // ��� ������� 1 ������ ���� ������� � ���������.
        Time.timeScale = 1;
    }
}
