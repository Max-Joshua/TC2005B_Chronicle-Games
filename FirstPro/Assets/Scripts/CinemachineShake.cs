using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/* 
Chronicle Games
04/15/2022

-> This script creates a camara shake effect, the camera will quickly and randomly move 
    in small amounts and short bursts to give this illusion.
 

*/

public class CinemachineShake : MonoBehaviour{

public static CinemachineShake Instance { get; private set; }

private CinemachineVirtualCamera cinemachineVirtualCamera;
private float shakeTimer;

    private void Awake() {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    //Obtain the noise commponent which is the one that will give the shaking effect, Multi Channel Perlin is the specific 
    //type of noise that we will be using for this script
    
    public void ShakeCamera(float intensity, float time){
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = 
        cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;

    }
    private void Update(){
        if(shakeTimer > 0){
            shakeTimer -= Time.deltaTime;
            if(shakeTimer <= 0f){
                //Time Over!
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = 
                cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }
    }

}
