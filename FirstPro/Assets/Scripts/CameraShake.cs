using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 
Chronicle Games
04/05/2022

-> This script creates a camara shake effect, the camera will quickly and randomly move 
    in small amounts and short bursts to give this illusion.

*/
public class CameraShake : MonoBehaviour
{
    [SerializeField] Transform transform;
    public float shakeDuration;
    public float shakeMagnitude;
    public float dampingSpeed;
    Vector3 initialPosition;
    


    void Awake()
    {
        if (transform == null)
        {
            transform = GetComponent(typeof(Transform)) as Transform;
        }
    }
    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
    if (shakeDuration > 0)
    {
    transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
    
    shakeDuration -= Time.deltaTime * dampingSpeed;
    Debug.Log(transform.localPosition);
    }
    else
    {
    shakeDuration = 0f;
    transform.localPosition = initialPosition;
        }
    }

    public void TriggerShake() {
      Debug.Log("SHAKINGGGG");
      shakeDuration = 10.0f;
    }
}
