using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera Cine;
    [SerializeField] private float ShakeIntensity = 1.0f;
    [SerializeField] private float ShakeTime = 0.2f;
    private float timer;
    private CinemachineBasicMultiChannelPerlin _cbmcp;


    private void Awake()
    {
        Cine= GetComponent<CinemachineVirtualCamera>();
    }
    private void Start()
    {
        
        Cine = GetComponent<CinemachineVirtualCamera>();
        StopShake();
    }
    public void ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = Cine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = ShakeIntensity;
        timer = ShakeTime;
    }
    private void StopShake()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = Cine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = 0f;
        timer = 0;
    }

    public void StartShake() 
    {
        StartCoroutine(CountShake());
    }

    IEnumerator CountShake() 
    { 
        ShakeCamera();
        yield return new WaitForSeconds(ShakeTime);
        StopShake();
    }

    void Update()
    {

    }
}
