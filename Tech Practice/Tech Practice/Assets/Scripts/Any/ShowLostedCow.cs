using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLostedCow : MonoBehaviour
{
    public SceneChangeNumder scCh;
    private int count;
    public GameObject lostedCow;

    void Start()
    {
        count = scCh.sceneChangeCount;
        if (count < 5)
        {
            lostedCow.SetActive(true);
        }
    }
}
