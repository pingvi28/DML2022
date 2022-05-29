using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutdownWaterScript : MonoBehaviour
{
    public FlagTrigger flag;

    void Start()
    {
        gameObject.GetComponent<ShutdownWaterScript>().enabled = flag.status;
    }
}
