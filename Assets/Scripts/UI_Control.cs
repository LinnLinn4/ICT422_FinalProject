using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Control : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject controlsCanvas;
    public string storyline1;
    public string storyline2;
    public bool firstTime = false;

    public void PlayButton()
    {
        menuCanvas.SetActive(false);
        Dialogue_Control.instance.DialogueCanvas_Activate(storyline1);
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

    public void SkipButton()
    {
        if (firstTime)
        {
            SceneManager.LoadScene("Game");
            Time.timeScale = 1;
            return;
        }
        Dialogue_Control.instance.DialogueCanvas_Deactivate();
        Dialogue_Control.instance.DialogueCanvas_Activate(storyline2);
        firstTime = true;
        //Dialogue_Control.instance.DialogueCanvas_Deactivate();
        //SceneManager.LoadScene("Game");
    }

}
