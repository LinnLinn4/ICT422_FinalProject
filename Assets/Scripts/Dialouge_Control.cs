using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue_Control : MonoBehaviour
{
    public GameObject dialogueCanvas;
    public TMP_Text dialogueText;
    public static Dialogue_Control instance;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void DialogueCanvas_Activate(string text)
    {
        dialogueText.text = text;
        dialogueCanvas.SetActive(true);
        //StartCoroutine(DeactivateAfterSeconds(3f));
    }

    public void DialogueCanvas_Deactivate_Delay()
    {
        StartCoroutine(DelayRun(3f, () =>
        {
            dialogueCanvas.SetActive(false);
        }));

    }
    public void DialogueCanvas_Deactivate()
    {
        dialogueCanvas.SetActive(false);

    }

    private IEnumerator DelayRun(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);

        action.Invoke();
    }
}
