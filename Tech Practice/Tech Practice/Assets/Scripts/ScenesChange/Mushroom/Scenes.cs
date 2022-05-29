using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour//, IPointerClickHandler
{
    public Quest qu;

    /*
    public void OnPointerClick(PointerEventData eventData) 
    {
        if (qu.flag)
        {
            NextLevel();
        }
    }*/

    private void OnTriggerStay(Collider other)
    {
        if (qu.questNumber == 1 && other.CompareTag("Player"))
        {
            NextLevel();
            qu.increaseQueuestNumber();
        }
    }

    public void NextLevel() 
    {
        SceneManager.LoadScene("Intermediate");
    }
}

