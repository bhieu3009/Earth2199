using UnityEngine;
using UnityEngine.SceneManagement;
public class GameUi : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameManager gameManager; 
    public void StartGame()
    {
        gameManager.StartGame();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ResumeGame()
    {
        gameManager.Resume();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
