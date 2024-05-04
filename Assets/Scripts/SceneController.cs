using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused = false;

    //Ensures pause menu starts disabled
    private void Start() { pauseMenu.SetActive(false); }

    //Exit To Desktop
    public void ExitGame() { Application.Quit(); }

    //Restart Current Level
    public void RestartLevel() { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }

    //Return To Main Menu
    public void ReturnToMenu() { SceneManager.LoadScene("Title"); }

    //Load specific level
    public void LoadLevel(string _sceneName) { SceneManager.LoadScene(_sceneName); }

    //Gets current scene name
    public string GetSceneName() { return SceneManager.GetActiveScene().name; }

    //Pause Toggle | if Main Menu is active scene, attempting to pause will guarantee that pause is not active
    public void TogglePause() { if (SceneManager.GetActiveScene().name != "Title") { isPaused = !isPaused; if (isPaused) { pauseMenu.SetActive(false); Time.timeScale = 1; } else { pauseMenu.SetActive(true); Time.timeScale = 0; } }else{isPaused = false;} }

}
