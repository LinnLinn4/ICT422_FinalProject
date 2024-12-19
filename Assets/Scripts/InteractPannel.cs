using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractPannel : MonoBehaviour
{
    public GameObject dialogueCanvas;
    public TMP_Text dialogueText;
    public static InteractPannel instance;


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

    public void Int_Activate(string text)
    {
        dialogueText.text = text;
        dialogueCanvas.SetActive(true);
    }

    public void Int_Deactivate()
    {
        dialogueCanvas.SetActive(false);
    }

}
