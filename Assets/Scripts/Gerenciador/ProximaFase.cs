using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProximaFase : MonoBehaviour
{
    [SerializeField] GameObject canvastrans;
    [SerializeField] int proximaFase;
    void Start()
    {

    }

   
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canvastrans.SetActive(true);
            Invoke("teleportDelay", 3f);
        }
    }
    void teleportDelay() 
    {
        SceneManager.LoadScene(proximaFase);
    }
}
