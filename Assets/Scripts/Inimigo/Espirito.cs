using UnityEngine;

public class Espirito : MonoBehaviour
{
    public float amplitude = 0.5f; // Amplitude do movimento de flutua��o
    public float velocidade = 1.0f; // Velocidade do movimento de flutua��o
    public float distanciaDeAtaque = 2.0f; // Dist�ncia de ataque do inimigo
    public int danoDoAtaque = 10; // Dano causado pelo ataque do inimigo
    public int hp = 50; // Pontos de vida do inimigo
    public Animator animador; // Refer�ncia ao Animator do inimigo
    Gilmar player;

    private Vector3 posicaoInicial; // Posi��o inicial do inimigo

    private void Start()
    {
        posicaoInicial = transform.position; // Salva a posi��o inicial do inimigo
        player = FindObjectOfType<Gilmar>();
    }

    private void Update()
    {
        // Calcula a posi��o vertical usando a fun��o seno para criar um movimento de flutua��o
        float movimentoVertical = Mathf.Sin(Time.time * velocidade) * amplitude;

        // Atualiza a posi��o do inimigo com a posi��o inicial e o movimento vertical
        transform.position = posicaoInicial + new Vector3(0, movimentoVertical, 0);

        // Verifica a dist�ncia entre o inimigo e o jogador
        float distanciaAoJogador = Vector3.Distance(transform.position, player.transform.position);
        if (distanciaAoJogador < distanciaDeAtaque)
        {
            
            if (animador != null)
            {
                animador.SetTrigger("Atacar");
            }
        }
    }

    public void SofrerDano(int quantidade)
    {
        hp -= quantidade;

        // Verifica se o inimigo est� morto
        if (hp <= 0)
        {
            Morrer();
        }
        else
        {
            // Se ainda tem pontos de vida, executa a anima��o de dano (se houver)
            if (animador != null)
            {
                animador.SetTrigger("Dano");
            }
        }
    }

    private void Morrer()
    {
       
        if (animador != null)
        {
            animador.SetTrigger("Morrer");
        }
        
        Destroy(gameObject);
    }
}
