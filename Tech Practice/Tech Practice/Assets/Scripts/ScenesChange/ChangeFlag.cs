using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFlag : MonoBehaviour
{
    public FlagTrigger flag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            flag.setFalse();
        }
    }
}
