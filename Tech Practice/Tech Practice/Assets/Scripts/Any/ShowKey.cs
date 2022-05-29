using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowKey : MonoBehaviour
{
    public SceneChangeNumder scCh;
    private int count;
    public GameObject key;

    void Start()
    {
        count = scCh.sceneChangeCount;
        if (count == 3 || count == 4 )
        {
            key.SetActive(true);
        }
    }
}
