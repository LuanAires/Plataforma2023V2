using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudBossController : MonoBehaviour
{
    public int maxlife;
    public int currentylife;
    [SerializeField] private float multiplier;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(currentylife * multiplier / maxlife, 1, 1);
    }
}


