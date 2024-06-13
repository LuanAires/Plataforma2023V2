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
        // Atribui a vari�vel vmCam caso n�o esteja definida no Inspector
        if (vmCam == null)
        {
            vmCam = FindObjectOfType<CinemachineVirtualCamera>();
        }
    }

    private void Update()
    {
        // Atualiza��o desnecess�ria do shake movida para a coroutine
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Grades.SetActive(true);
            animator.SetBool("Fechado", true);
            portaFechando.Play();

            // Inicia a coroutine para aguardar o t�rmino da anima��o
            StartCoroutine(AguardarAnimacaoEAgitar());
        }
    }

    private IEnumerator AguardarAnimacaoEAgitar()
    {
        // Aguarda at� que a anima��o "Fechado" termine
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("Fechado") &&
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }

        // Inicia o shake da c�mera ap�s a anima��o terminar
        if (shakeValidade)
        {
            vmCam.GetComponent<CameraShake>().StartShake();
            Debug.Log("Shake");
        }
    }
}
