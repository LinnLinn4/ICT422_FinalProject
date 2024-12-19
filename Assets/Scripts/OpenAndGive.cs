using System.Linq;
using UnityEngine;

public class OpenAndGive : MonoBehaviour
{
    public bool opened = false;


    public string itemToGive = "";


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

                GetComponent<Animator>().SetTrigger("open");
                opened = true;
                InteractPannel.instance.Int_Deactivate();
                GameState.addPlayerItem(itemToGive.Length == 0 ? GameState.availItem.First(): itemToGive);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        InteractPannel.instance.Int_Deactivate();
    }

}
