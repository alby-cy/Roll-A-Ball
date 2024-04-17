using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuController : MonoBehaviour
{

    public void StartGame() { UnityEngine.SceneManagement.SceneManager.LoadScene("Level_1"); }

    public void ExitGame() { Application.Quit(); }

    public void RestartLevel() { UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name); }

}
