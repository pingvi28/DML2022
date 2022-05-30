using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class OvenQU : MonoBehaviour//, IPointerClickHandler
{
    public Inventory inventory;
    public Quest quest;
    public GameObject backet;
    public GameObject lopata;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("t1")) {
            if (other.gameObject.GetComponent<PickUp>().id == 2)
            {
                lopata.SetActive(true);
            }

            if (quest.questNumber == 5)
            {
                backet.SetActive(true);
            }
        }
    }
}
