using Gamekit3D.GameCommands;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.WSA;

public class CheckAndTrigger : MonoBehaviour
{
    public List<string> itemsToCheck = new List<string> { "key" };

    public bool activate = false;

    float time = 0f;
    void Update()
    {
        float d = 1f;
        if (!activate)
        {
            d = -1f;
        }
        time = Mathf.Clamp01(time + (d * Time.deltaTime / 4f));
        GetComponent<SimpleTranslator>().PerformTransform(time);
    }

    public void check()
    {
        for (int i = 0; i < itemsToCheck.Count; i++)
        {
            if (!GameState.playerItem.Contains(itemsToCheck[i]))
            {
                return;
            }
        }
        activate = true;
    }

    public void close()
    {
        Debug.Log("Exit");
        activate = false;
    }
}
