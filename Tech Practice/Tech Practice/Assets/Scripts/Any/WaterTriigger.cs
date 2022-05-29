using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTriigger : MonoBehaviour
{
    public SceneChangeNumder scCh;
    private int count;
    public GameObject objectTrig;
    public GameObject objectWithoutTrig;

    void Start()
    {
        count = scCh.sceneChangeCount;
        if (count < 3)
        {
            objectTrig.SetActive(true);
            objectWithoutTrig.SetActive(false);
        }
        else {
            objectTrig.SetActive(false);
            objectWithoutTrig.SetActive(true);
        }
    }
}
