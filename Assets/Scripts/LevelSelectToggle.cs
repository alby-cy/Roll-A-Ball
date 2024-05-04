using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectToggle : MonoBehaviour
{

    public GameObject menuCanvas;
    public GameObject levelSelectCanvas;

    private bool isMainActive = true;

    void Start() { //make sure correct screen is shown on wake
        menuCanvas.SetActive(true);
        levelSelectCanvas.SetActive(false);
    }

    // Swap between Main Menu and Level Select
    public void ToggleLevels()
    {
        if (isMainActive) {
            menuCanvas.SetActive(false);
            levelSelectCanvas.SetActive(true);
            isMainActive = false;
        }else {
            menuCanvas.SetActive(true);
            levelSelectCanvas.SetActive(false);
            isMainActive = true;
        }
        
    }
}
