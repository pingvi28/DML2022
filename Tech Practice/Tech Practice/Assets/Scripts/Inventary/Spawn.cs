using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    public VectorValue vv;

    public void SpawnDroppedItem()
    {
        Vector3 playerPos = new Vector3(vv.initialValue.x + 5 , vv.initialValue.y + 5, vv.initialValue.z +15);
        Instantiate(item, playerPos, Quaternion.identity);
    }
}
