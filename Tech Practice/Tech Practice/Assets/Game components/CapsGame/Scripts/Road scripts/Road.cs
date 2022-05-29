using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public int number;
    public float maxPosZ;

    private string statusActiveVar = "";
    private string statusOffVar = "";
    private int currentVariant;

    public GameObject[] Variants;

    private void FixedUpdate() 
    {
        if (transform.localPosition != new Vector3(0, 0, -40))
        {
            if (transform.localPosition.z < maxPosZ)
            {
                if (statusActiveVar == "")
                {
                    currentVariant = Random.Range(0, Variants.Length);
                    Variants[currentVariant].SetActive(true);
                    statusActiveVar = "Active";
                    statusOffVar = "Check";
                }
            }
        }
        else {
            if (statusOffVar == "Check")
            {
                Variants[currentVariant].SetActive(false);
                statusActiveVar = "";
                statusOffVar = "";
            }
        }
    }
}
