using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SceneChangeNumder : ScriptableObject
{
    public int sceneChangeCount;

    public void IncreaseScCount()
    {
        sceneChangeCount++;
    }

    public void ReduseScCount()
    {
        sceneChangeCount--;
    }

    public void SetNewCount()
    {
        sceneChangeCount = 0;
    }
}
