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
    public List<string> itemsToCheck = new List<string> { "key", "battery", "access-card", "screwdriver", "wire", "harddisk", "security-pass", "gear"};

    public bool activate = false;
    public float duration = 4f;
    float time = 0f;
    void Update()
    {
        float d = 1f;
        if (!activate)
        {
            d = -1f;
        }
        time = Mathf.Clamp01(time + (d * Time.deltaTime / duration));
        GetComponent<SimpleTranslator>().PerformTransform(time);
    }

    public void check()
    {
        for (int i = 0; i < itemsToCheck.Count; i++)
        {
            if (!GameState.playerItem.Contains(itemsToCheck[i]))
            {
                Dialogue_Control.instance.DialogueCanvas_Activate($"You haven't collected {itemsToCheck[i]}");

                return;
            }
        }
        activate = true;
    }

    public void close()
    {
        Dialogue_Control.instance.DialogueCanvas_Deactivate();
        Debug.Log("Exit");
        activate = false;
    }
}
