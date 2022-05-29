using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidSceneData : MonoBehaviour
{
    private static MidSceneData _instance;
    public static MidSceneData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (new GameObject("_MidScenesData")).AddComponent<MidSceneData>();
            }
            DontDestroyOnLoad(_instance.gameObject);

            return _instance;
        }
    }

    public Vector3 characterPosition;
}
