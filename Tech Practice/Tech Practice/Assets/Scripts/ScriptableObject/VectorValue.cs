using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VectorValue : ScriptableObject
{
    public Vector3 initialValue;

    public void SetNewPosition(Vector3 vec)
    {
        initialValue.x = vec.x;
        initialValue.y = vec.y;
        initialValue.z = vec.z;
    }
}