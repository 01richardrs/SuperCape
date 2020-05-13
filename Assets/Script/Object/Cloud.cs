using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed = 0.1f;
 
    void Update()
    {
        transform.Translate((Vector3.left * speed) * Time.deltaTime);
    }
}
