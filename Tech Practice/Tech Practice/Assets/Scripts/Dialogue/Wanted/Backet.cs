using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class Backet : MonoBehaviour//, IPointerClickHandler
{
    public Quest quest;
    public TextNumber num;
    

    private void OnTriggerStay(Collider other)
    {
        if (quest.questNumber == 5 && other.CompareTag("Player"))
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
