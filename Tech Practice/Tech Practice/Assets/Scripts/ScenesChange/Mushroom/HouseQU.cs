using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class HouseQU : MonoBehaviour//, IPointerClickHandler
{
    public Quest qu;
    public Inventory inventory;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("=)");

        if (qu.questNumber == 2 && other.CompareTag("Player"))
        {
            Debug.Log("sdsds");
            if (inventory.isFull[0] == true || inventory.isFull[1] == true) {
                Debug.Log("sdsd");
                NextLevel();
            }
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Intermediate");
    }
}

