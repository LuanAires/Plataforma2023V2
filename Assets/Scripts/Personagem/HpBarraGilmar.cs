using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarraGilmar : MonoBehaviour
{


    public int maxlife;
    public int currentylife;
    public int maxMana;
    public int currentmana;
    [SerializeField] private float multiplier;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(currentylife * multiplier / maxlife, 1, 1);
        transform.localScale = new Vector3(currentylife * multiplier / maxMana, 1, 1);
    }
}