using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float velocidade = 0;
    private float length;
    private float startPos;
    private Transform Cam;
    public float ParalaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float Distance = Cam.transform.position.x * ParalaxEffect;
        Cam= Camera.main.transform;
        transform.position = new Vector3(startPos+ Distance,transform.position.y,transform.position.z);
        MoveFundo();
    }

    void MoveFundo()
    {
        float posX = transform.position.x - velocidade * Time.deltaTime * Input.GetAxis("Horizontal");
        transform.position = new Vector3(posX, 0, 0);
    }
}
