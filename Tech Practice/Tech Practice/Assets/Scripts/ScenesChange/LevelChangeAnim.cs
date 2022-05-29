using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangeAnim : MonoBehaviour
{
    private Animator anim;

    private void Start() 
    {
        anim = GetComponent<Animator>();
    }

    public void GameOver()
    {
        anim.SetTrigger("over");
    }

    public void FadeToLevel() 
    {
        anim.SetTrigger("fade");
    }
}