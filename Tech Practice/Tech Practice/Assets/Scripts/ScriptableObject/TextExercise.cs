using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TextExercise : ScriptableObject
{
    public int textExerciseCount;

    public void IncreaseScCount()
    {
        textExerciseCount++;
    }

    public void ReduseScCount()
    {
        textExerciseCount--;
    }

    public void SetNewCount()
    {
        textExerciseCount = 0;
    }
}
