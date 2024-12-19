using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;


public class PasswordManager : MonoBehaviour
{
    public TMP_InputField inputfield;
    public GameObject PWPanel;
    public GameObject intercom;

    bool opened = false;

    private void OnTriggerExit(Collider other)
    {
        InteractPannel.instance.Int_Deactivate();
    }

    void OnTriggerStay(Collider other)
    {
        if (opened)
        {
            return;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            if (!opened)
            {
                InteractPannel.instance.Int_Activate("Press F to open");
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                PWPanel.SetActive(true);
            }
        }

    }
    void toggleCursor(bool value)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = value;
        if (value)
        {
            PlayerInput.Instance.ReleaseControl();
        }
        else
        {
            PlayerInput.Instance.GainControl();
        }
    }

    void Update()
    {

        if (opened) return;
        if (PWPanel != null && PWPanel.activeSelf)
        {
            toggleCursor(PWPanel.activeSelf);
        }
        if (PWPanel.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            CheckInput();
        }
    }

    public void CheckInput()
    {

        if (inputfield.text == "4186")      // check password
        {
            opened = true;
            Debug.Log("Password accepted");
            PWPanel.SetActive(false);
            InteractPannel.instance.Int_Deactivate();
        }
        else
        {
            Debug.Log("Incorrect Password");
            PWPanel.SetActive(false);
            //PWIncorrectPanel.SetActive(true);
        }
        inputfield.text = "";
        toggleCursor(PWPanel.activeSelf);
    }

}