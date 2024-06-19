using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudBossController : MonoBehaviour
{
    public float maxlife;
    public float currentylife;
    [SerializeField] private float multiplier;
    private Vector3 initialScale;

    void Start()
    {
        // Salva a escala inicial da barra
        initialScale = transform.localScale;

        // Encontra o jogador na cena
        player = FindObjectOfType<Gilmar>();

        if (player != null)
        {
            maxlife = player.maxLife;
            currentylife = player.hp;
        }

        // Configura a barra com base na vida máxima
        UpdateHealthBar();
    }

    void Update()
    {
        if (player != null)
        {
            currentylife = player.hp;
            // Atualiza a barra de vida com base na vida atual
            UpdateHealthBar();
        }
    }

    private void UpdateHealthBar()
    {
        // Calcula a nova escala proporcional à vida atual
        float lifeRatio = currentylife / maxlife;
        transform.localScale = new Vector3(initialScale.x * lifeRatio * multiplier, initialScale.y);
    }
}
