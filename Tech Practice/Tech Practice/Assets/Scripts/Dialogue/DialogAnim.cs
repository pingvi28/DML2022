using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogAnim : MonoBehaviour
{
    public Animator startAnim;
    public DialogueManager dm;

    private void OnTriggerEnter(Collider other)
    {
        startAnim.SetBool("startOpen", true);
    }

    private void OnTriggerExit(Collider other)
    {
        startAnim.SetBool("startOpen", false);
        dm.EndDialogue();
    }
}
