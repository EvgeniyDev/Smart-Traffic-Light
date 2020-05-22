using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuListScript : MonoBehaviour
{
    public void BackToMainMenu() => SceneManager.LoadScene("MainMenu");

    public void QuitGame() => Application.Quit();
}
