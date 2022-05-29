using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TextNumber : ScriptableObject
{
    public int count;

    public void IncreaseCount()
    {
        count++;
    }

    public void RuduseCount()
    {
        count--;
    }

    public void SetNewCount()
    {
        count = 0;
    }
}
