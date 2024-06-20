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
     
        UpdateHealthBar();
    }

    void Update()
    {
        
       UpdateHealthBar();
        
    }

    private void UpdateHealthBar()
    {
        // Calcula a nova escala proporcional à vida atual
        float lifeRatio = currentylife / maxlife;
        transform.localScale = new Vector3(initialScale.x * lifeRatio * multiplier, initialScale.y);
    }
}
