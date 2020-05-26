using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadgame : MonoBehaviour
{
    // Start is called before the first frame update
    public void loadlevel()
    {
        SceneManager.LoadScene("Game");
    }
    public void Exit_Game()
    {
        Application.Quit();
    }
}
