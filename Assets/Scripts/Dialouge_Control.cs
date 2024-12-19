using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue_Control : MonoBehaviour
{
    public GameObject dialogueCanvas;
    public TMP_Text dialogueText;
    public static Dialogue_Control instance;
    

    void Awake()
    {
        if(instance == null)
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

    public void DialogueCanvas_Deactivate(float duration = 3f)
    {
        StartCoroutine(DeactivateAfterSeconds(duration));
        dialogueCanvas.SetActive(false);
    }

    private IEnumerator DeactivateAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        DialogueCanvas_Deactivate();
    }
}
