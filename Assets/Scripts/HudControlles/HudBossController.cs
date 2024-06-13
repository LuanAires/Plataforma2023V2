using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudBossController : MonoBehaviour
{
    public int maxlife;
    public int currentylife;
    [SerializeField] private float multiplier;

    void Start()
    {

    }
    void Update()
    {
        transform.localScale = new Vector3(currentylife * multiplier / maxlife, 1, 1);
    }
}