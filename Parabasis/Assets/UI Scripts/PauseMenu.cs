using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject glow;
    
    [SerializeField] GameObject pauseMenu;

  
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        
        if (gameObject.name == "MaskMenu")
        {
            glow.SetActive(false);
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}