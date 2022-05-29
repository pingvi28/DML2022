using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FlagTrigger : ScriptableObject
{
    public bool status;

    public void setTrue() 
    {
        status = true;
     }

    public void setFalse() 
    {
        status = false;
    }
    
}
