using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCloud : MonoBehaviour
{
    public Animator[] clouds;
    public GameObject cloudImg;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach(Animator anim in clouds)
            {
                cloudImg.SetActive(true);
                anim.SetTrigger("isTriggered");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Animator anim in clouds)
            {
                cloudImg.SetActive(false);
                anim.SetTrigger("isTriggered");
            }
        }
    }
}
