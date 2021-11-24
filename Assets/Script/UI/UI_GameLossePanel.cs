using UnityEngine;
using UnityEngine.SceneManagement;
public class UI_GameLossePanel : MonoBehaviour
{
    public void ToHomeMaps()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void RestartMaps()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void MapsMission()
    {
        SceneManager.LoadScene(1); // ��� ������� 1 ������ ���� ������� � ���������.
        Time.timeScale = 1;
    }
}
