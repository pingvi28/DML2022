using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class BoyQU : MonoBehaviour//, IPointerClickHandler
{
    public Quest qu;

    private void OnTriggerStay(Collider other)
    {
        try
        {
            if (qu.questNumber == 1 && other.CompareTag("Player"))
            {
                NextLevel();
            }
        }
        catch (System.Exception ex) { Debug.Log("aaaa"); }

    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Intermediate");
    }
}

