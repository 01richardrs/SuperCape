using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLevelBG : MonoBehaviour
{
    public float speed;
    public float StartX;
    public float endX;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= endX)
        {
            Vector2 pos = new Vector2(StartX, transform.position.y);
            transform.position = pos;
        }
    }
}
