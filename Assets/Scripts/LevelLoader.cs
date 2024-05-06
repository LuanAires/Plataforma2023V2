using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator TransitionAnim;

    public void Transition(string sceneName)
    {
      StartCoroutine(LoadScene(sceneName));
    }
    IEnumerator LoadScene (string sceneName) 
    {
        TransitionAnim.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene (sceneName);
    
    }
}
