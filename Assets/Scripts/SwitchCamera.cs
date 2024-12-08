using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject secCam;
    public bool isMainCam = true;

    public void toggleCam()
    {
        if (isMainCam)
        {
            mainCam.SetActive(false);
            secCam.SetActive(true);
        }
        else
        {
            mainCam.SetActive(true);
            secCam.SetActive(false);
        }
        isMainCam = !isMainCam;
    }
}
