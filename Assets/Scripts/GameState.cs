using Gamekit3D;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    static public List<string> playerItem = new List<string>();


    public GameObject ellen;
    public GameObject pod;
    public GameObject endGameCanvas;
    public GameObject camera1;
    public GameObject p;

    static public void addPlayerItem(string item)
    {


        if (Dialogue_Control.instance != null)
        {
            Dialogue_Control.instance.DialogueCanvas_Activate($"You have found the {item}");
            Dialogue_Control.instance.DialogueCanvas_Deactivate_Delay();
        }
        else
        {
            Debug.LogError("Dialogue_Control.instance is null. Ensure Dialogue_Control is in the scene.");
        }
        Debug.Log(item + " collected");
        playerItem.Add(item);

    }
    public void endGame()
    {
        ellen.SetActive(false);
        camera1.GetComponent<CameraSettings>().follow = pod.transform;
        camera1.GetComponent<CameraSettings>().lookAt = pod.transform;
        StartCoroutine(DelayRun(7.5f, () =>
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            endGameCanvas.SetActive(true);
        }));
    }
    public void goHomeEndGame()
    {
        SceneManager.LoadScene("Home");
        endGameCanvas.SetActive(false);
    }
    public void restart()
    {
        p.GetComponent<StartUI>().ExitPause();
        SceneManager.LoadScene("game");
    }
    public void home()
    {
        SceneManager.LoadScene("Home");
    }
    private IEnumerator DelayRun(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);

        action.Invoke();
    }
}
