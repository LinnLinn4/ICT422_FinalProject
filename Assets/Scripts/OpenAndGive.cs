using System.Linq;
using UnityEngine;

public class OpenAndGive : MonoBehaviour
{
    public bool opened = false;
    

    void OnTriggerStay(Collider other)
    {
        if (opened)
        {
            return;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Dialogue_Control.instance.DialogueCanvas_Activate("Press F to open");
            if (Input.GetKeyDown(KeyCode.F))
            {
                Dialogue_Control.instance.DialogueCanvas_Deactivate(0.0f);
                GetComponent<Animator>().SetTrigger("open");
                opened = true;
                GameState.addPlayerItem(GameState.availItem.First());
                Debug.Log("opened");
            }
        }

    }
}
