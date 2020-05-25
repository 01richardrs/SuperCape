using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    GameObject Player;
    public Transform camTransform;
    public float shakeDuration = 0f;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;
    // Start is called before the first frame update
    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }
    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }
    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player.GetComponent<PlayerMovement>().GiantStatus == true && Player.GetComponent<PlayerMovement>().jumpStatus == false)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
        }
        else 
        {
            camTransform.localPosition = originalPos;
        }
   
    }
}
