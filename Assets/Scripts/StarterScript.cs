using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterScript : MonoBehaviour
{
    public bool gameIsStarted = false;
   
    void Start()
    {
        //Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsStarted == false)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void StartGame()
    {
        gameIsStarted = true;
       
    }
}
