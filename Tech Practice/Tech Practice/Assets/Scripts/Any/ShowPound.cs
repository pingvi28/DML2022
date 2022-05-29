using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPound : MonoBehaviour
{
    public SceneChangeNumder scCh;
    private int count;
    public GameObject pound;
    public GameObject rob;
    public GameObject robot_cloud;

    void Start()
    {
        count = scCh.sceneChangeCount;
        if (count ==  5)
        {
            rob.SetActive(false);
            robot_cloud.SetActive(false);
            pound.SetActive(true);
        }
    }
}
