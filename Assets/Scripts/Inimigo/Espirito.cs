using UnityEngine;

public class Espirito : MonoBehaviour
{
    public float amplitude = 0.5f; // Amplitude do movimento de flutuação
    public float velocidade = 1.0f; // Velocidade do movimento de flutuação
    public float distanciaDeAtaque = 2.0f; // Distância de ataque do inimigo
    public int danoDoAtaque = 10; // Dano causado pelo ataque do inimigo
    public int hp = 50; // Pontos de vida do inimigo
    public Animator animador; // Referência ao Animator do inimigo
    Gilmar player;

    private Vector3 posicaoInicial; // Posição inicial do inimigo

    private void Start()
    {
        posicaoInicial = transform.position; // Salva a posição inicial do inimigo
        player = FindObjectOfType<Gilmar>();
    }

    private void Update()
    {
        // Calcula a posição vertical usando a função seno para criar um movimento de flutuação
        float movimentoVertical = Mathf.Sin(Time.time * velocidade) * amplitude;

        // Atualiza a posição do inimigo com a posição inicial e o movimento vertical
        transform.position = posicaoInicial + new Vector3(0, movimentoVertical, 0);

        // Verifica a distância entre o inimigo e o jogador
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

        // Verifica se o inimigo está morto
        if (hp <= 0)
        {
            Morrer();
        }
        else
        {
            // Se ainda tem pontos de vida, executa a animação de dano (se houver)
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
