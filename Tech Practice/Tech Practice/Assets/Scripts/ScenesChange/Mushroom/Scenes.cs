using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour//, IPointerClickHandler
{
    public Quest qu;
    private Animator animator;

    /*
    public void OnPointerClick(PointerEventData eventData) 
    {
        if (qu.flag)
        {
            NextLevel();
        }
    }*/

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (qu.questNumber == 1 && other.CompareTag("Player"))
        {
            //gameObject.SetActive(false);

            animator.SetBool("quest", true);
            qu.increaseQueuestNumber();
        }
    }

    public void NextLevel() 
    {
        SceneManager.LoadScene("Intermediate");
    }
}

