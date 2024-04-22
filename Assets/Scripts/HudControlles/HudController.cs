using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Mathematics;

public class HudController : MonoBehaviour
{
    public float BarHp;
    private float barHp;
    
    private float aveHP
    {
        get
        {
            return barHp / BarHp;
        }
    }
    public TextMeshProUGUI HPTxt;
    private Image FillBar;
    public float BarDmg;
    // Start is called before the first frame update
    void Start()
    {
        barHp = BarHp;
        /*HPTxt = Mathf.FloorToInt(barHp).ToString();*/
       /* FillBar.fillAmount = aveHP;*/
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            reduceBar(BarDmg);
        }      
    }

    void reduceBar ( float dmg) 
    {
        barHp= dmg;
        UpdateUI();
    }
    void UpdateUI () 
    { 
      /*HPTxt.text = math.floor(barHp).ToString();*/
        FillBar.fillAmount = aveHP;
    
    }
}
