using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera CinemachineVirtualcamera;
    private float ShakeIntensity = 1.0f;
    private float ShakeTime = 0.2f;
    private float timer;
    private CinemachineBasicMultiChannelPerlin _cbmcp;
    private SalaBoss sala;


    private void Awake()
    {
        CinemachineVirtualcamera= GetComponent<CinemachineVirtualCamera>();
    }
    private void Start()
    {
        StopShake();
    }
    public void ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = CinemachineVirtualcamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = ShakeIntensity;
        timer = ShakeTime;
    }
    private void StopShake()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = CinemachineVirtualcamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain -= 0f;
        timer = 0;
    }
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape)) 
       {
            ShakeCamera();
       }
        if (timer > 0) 
        {
          timer -= Time.deltaTime;

            if(timer <= 0)  
            {
              StopShake();
            
            }
        }
    }
}
