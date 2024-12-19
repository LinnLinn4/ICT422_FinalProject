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

            if (Input.GetKeyDown(KeyCode.F))
            {
                GetComponent<Animator>().SetTrigger("open");
                opened = true;
                GameState.addPlayerItem(GameState.availItem.First());
                Debug.Log("opened");
            }
        }

    }
}
