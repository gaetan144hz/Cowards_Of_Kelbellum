using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowReadyButton : MonoBehaviour
{

    public GameObject startButton;

    public int numberOfPlayers = 0;

    void Update()
    {
        if (numberOfPlayers < 1)
        {
            startButton.SetActive(false);
            foreach(Transform child in transform) 
            {
                numberOfPlayers += 1;
            }
        }
        else
        {
            startButton.SetActive(true);
        }
    }
}
