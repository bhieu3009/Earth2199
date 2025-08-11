using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private int currentEnergy;
    [SerializeField] private int energyThreshold = 5;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject enenySpamer;
    private bool bossCalled = false;
    [SerializeField] private Image energyBar;
    [SerializeField] GameObject gameUi;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private GameObject red;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private CinemachineCamera cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentEnergy = 0;
        UpdateEnergyBar();//Gọi phương thuức 
        boss.SetActive(false);
        MainMenu();
        audioManager.StopAudioSource();
        cam.Lens.OrthographicSize = 5f;
        red.SetActive(false);
    }


    public void AddEnergy()
    {
        if (bossCalled) 
        {
            return;
        }

        currentEnergy += 1; 
        UpdateEnergyBar();

       
        if (currentEnergy == energyThreshold)
        {
            CallBoss();
        }
    }

    private void CallBoss()
    {
        bossCalled = true;
        boss.SetActive(true);
        enenySpamer.SetActive(false);
        gameUi.SetActive(false);//Xử lý khi thanh hp bar biến mất

        audioManager.BossAudioSource();
        cam.Lens.OrthographicSize = 7f;
        red.SetActive(true);
    }
    private void UpdateEnergyBar()
    {
        if (energyBar != null) // Kiểm tra xem energyBar có tồn tại không
        {
            float fillAmout = Mathf.Clamp01((float)currentEnergy / (float)energyThreshold); // Tính tỷ lệ năng lượng hiện tại
            energyBar.fillAmount = fillAmout; // Cập nhật thanh năng lượng trên UI
        }
    }
    public void MainMenu()
    {
        mainMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 0f;
    }
    public void GameOverMenu()
    {
        gameOverMenu.SetActive(true);
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 0f;
    }
    public void PauseGameMenu()
    {
        pauseMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        mainMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 1f;
        audioManager.PlayDefaultAudio();
    }
    public void Resume()
    {
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void WinGame()
    {
        winMenu.SetActive(true);
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 0f;
    }

}
