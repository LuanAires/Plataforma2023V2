using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera CinemachineVirtualcamera;
    private float ShakeIntensity = 1.0f;
    private float ShakeTime = 0.2f;
    private float timer;
    private CinemachineBasicMultiChannelPerlin _cbmcp;

    private void Awake()
    {
        CinemachineVirtualcamera= GetComponent<CinemachineVirtualCamera>();
    }
    private void Start()
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
        
    }
}
