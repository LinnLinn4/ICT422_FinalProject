using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameState : MonoBehaviour
{
    static public List<string> playerItem = new List<string>();

    static public List<string> availItem = new List<string> { "key", "battery" };


    static public void addPlayerItem(string item)
    {

        if (availItem.Contains(item))
        {
            availItem.Remove(item);
            playerItem.Add(item);
        }
    }
}
