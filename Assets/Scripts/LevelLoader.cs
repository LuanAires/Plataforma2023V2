using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator TransitionAnim;
    [SerializeField] ProximaFase prox;

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
    public void OnTriggerEnter2D(Collision2D collision)
    {
        TransitionAnim.GetBool("Prixima_Fase");
        if (collision.gameObject.CompareTag("Proxima_fase")(true))
        {
            


        }
    }
}