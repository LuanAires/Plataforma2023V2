using Cinemachine;
using System.Collections;
using UnityEngine;

public class GatilhoFechar : MonoBehaviour
{
    [SerializeField] GameObject Grades;
    public Animator animator;
    [SerializeField] public AudioSource portaFechando;
    private CinemachineVirtualCamera vmCam;
    [SerializeField] public bool shakeValidade;

    void Start()
    {
        // Atribui a variável vmCam caso não esteja definida no Inspector
        if (vmCam == null)
        {
            vmCam = FindObjectOfType<CinemachineVirtualCamera>();
        }
    }

    private void Update()
    {
        // Atualização desnecessária do shake movida para a coroutine
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Grades.SetActive(true);
            animator.SetBool("Fechado", true);
            portaFechando.Play();

            // Inicia a coroutine para aguardar o término da animação
            StartCoroutine(AguardarAnimacaoEAgitar());
        }
    }

    private IEnumerator AguardarAnimacaoEAgitar()
    {
        // Aguarda até que a animação "Fechado" termine
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("Fechado") &&
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }

        // Inicia o shake da câmera após a animação terminar
        if (shakeValidade)
        {
            vmCam.GetComponent<CameraShake>().StartShake();
            Debug.Log("Shake");
        }
    }
}
