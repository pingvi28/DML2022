using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ScenesWithTrigger : MonoBehaviour
{
    public string triggerTag;
    public string scenesChange;
    private bool turningOn = false;

    private void Start(){
        turningOn = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (turningOn && other.CompareTag(triggerTag))
        {
            NextLevel();
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(scenesChange);
    }
}
