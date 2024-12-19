using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Control : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject controlsCanvas;
    public GameObject dialogueCanvas;
    public GameObject dialogueText;

    public void PlayButton()
    {
        
        dialogueCanvas.SetActive(true);
        //SceneManager.LoadScene("Game");
    }

    public void ControlButton()
    {
        menuCanvas.SetActive(false);
        controlsCanvas.SetActive(true);
    }

    public void BackButton()
    {
        controlsCanvas.SetActive(false);
        menuCanvas.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

}
