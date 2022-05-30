using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class Backet : MonoBehaviour//, IPointerClickHandler
{
    public Quest quest;
    public TextNumber num;
    

    private void OnTriggerStay(Collider other)
    {
        quest.questNumber++;

        if (quest.questNumber == 6 && other.CompareTag("Player"))
        {
            num.SetNewCount();
            NextLevel();
        }
    }
    public void NextLevel()
    {
        SceneManager.LoadScene("Intermediate");
    }
}
