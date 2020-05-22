using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlayer : MonoBehaviour
{
    public int characterSelected;
    public GameObject character1;  
    public GameObject character2;

    // Start is called before the first frame update
    void Start()
    {
        characterSelected = PlayerPrefs.GetInt("selectcharacter");

        if(characterSelected == 0)
        {
            Instantiate(character1, this.transform.position, Quaternion.identity);
        }

        else if (characterSelected == 1)
        {
            Instantiate(character2, this.transform.position, Quaternion.identity);
        }
    
    }
}
