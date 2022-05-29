using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DontDestroySingleton : MonoBehaviour
{
    public static DontDestroySingleton plr;

    public void Awake()
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            if (!plr)
            {
                DontDestroyOnLoad(gameObject);
                plr = this;
            }
            else
            {
                plr.transform.position = transform.position;
                Destroy(gameObject);
            }
        }
    }
}