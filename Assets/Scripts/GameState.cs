using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameState : MonoBehaviour
{
    static public List<string> playerItem = new List<string>();

    static public List<string> availItem = new List<string> { "key", "battery", "access-card", "screwdriver", "wire", "harddisk", "gear"};


    static public void addPlayerItem(string item)
    {
        
        if (availItem.Contains(item))
        {
            if (Dialogue_Control.instance != null)
            {
                Dialogue_Control.instance.DialogueCanvas_Activate($"You have found the {item}");
            }
            else
            {
                Debug.LogError("Dialogue_Control.instance is null. Ensure Dialogue_Control is in the scene.");
            }
            Debug.Log(item + " collected");
            availItem.Remove(item);
            playerItem.Add(item);
            
            Dialogue_Control.instance.DialogueCanvas_Deactivate(5f);
        }
    }
}
