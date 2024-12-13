using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class PasswordManager : MonoBehaviour
{
    public TMP_InputField inputfield;
    public GameObject PWPanel;
    //public GameObject PWCorrectPanel;
    //public GameObject PWIncorrectPanel;
    public GameObject intercom;

     void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (intercom == GetClickedObject(out RaycastHit hit))
            {
                PWPanel.SetActive(true);
            }
        }

        if (PWPanel.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            CheckInput();
        }
    }
 
    public void CheckInput() {
        if (inputfield.text == "4186")      // check password
        {
            Debug.Log("Password accepted");
            PWPanel.SetActive(false);
            //PWCorrectPanel.SetActive(true);

        }
        else
        {
            Debug.Log("Incorrect Password");
            PWPanel.SetActive(false);
            //PWIncorrectPanel.SetActive(true);
        }
    }

     GameObject GetClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            if (!isPointerOverUIObject()) { target = hit.collider.gameObject; }
        }
        return target;
    }
    private bool isPointerOverUIObject()
    {
        PointerEventData ped = new PointerEventData(EventSystem.current);
        ped.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(ped, results);
        return results.Count > 0;
    }
}
