using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterchoice : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public void choose1()
    {
        PlayerPrefs.SetInt("selectcharacter", 0);
    }

    public void choose2()
    {
        PlayerPrefs.SetInt("selectcharacter", 1);
    }
}
