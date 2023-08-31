using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    [Header("//Menus")]
    [Space(5)]
    public GameObject mainMenu;
    public GameObject playMenu;
    public GameObject optionsMenu;
    public GameObject selectionMenu;


    void Start()
    {
        Debug.Log("MenuManager -- Game Started!");
        mainMenu.SetActive(true);
        playMenu.SetActive(false);
        optionsMenu.SetActive(false);
        selectionMenu.SetActive(false);
    }
    
    public void ToPlayMenu()
    {
        Debug.Log("MenuManager -- Going to play menu");
        mainMenu.SetActive(false);
        playMenu.SetActive(true);
    }

    public void ToOptionsMenu()
    {
        Debug.Log("MenuManager -- Going to options menu");
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void ToCharacterSelection()
    {
        Debug.Log("MenuManager -- Going to character selection");
        selectionMenu.SetActive(true);
        playMenu.SetActive(false);
    }

    public void GameQuit()
    {
        Debug.Log("MenuManager -- Quitting");
        Application.Quit();
    }

}
