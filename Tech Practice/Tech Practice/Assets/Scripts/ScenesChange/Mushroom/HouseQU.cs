using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class HouseQU : MonoBehaviour//, IPointerClickHandler
{
    public Quest qu;
    public Inventory inventory;
    public TextNumber num;

    private void OnTriggerStay(Collider other)
    {
        if (qu.questNumber == 2 && other.CompareTag("Player"))
        {
     
            if (inventory.isFull[0] == true || inventory.isFull[1] == true) {
                num.IncreaseCount();
                NextLevel();
            }
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Intermediate");
    }
}

