using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    // Hardcoded parameter value
    public void LoadFirstLevel() => SceneManager.LoadScene("FirstLevel");

    public void LoadSecondLevel() => SceneManager.LoadScene("SecondLevel");

    public void QuitGame() => Application.Quit();
}
