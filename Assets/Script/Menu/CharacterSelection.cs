using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelection : MonoBehaviour
{
    public int characterIndex = 0;
    public int playerIndex = 0;
    public Sprite[] sprites;
    
    public Image img;
    public TextMeshProUGUI characterText;

    private Character[] characters;

    void Awake()
    {
        characterIndex = 0;
        playerIndex = GameObject.FindGameObjectsWithTag("CharacterSelection").Length - 1;

        Debug.Log(playerIndex);

        characters = DataManager.Instance.GetCharacters().ToArray();

        
        UpdateSprite();
        UpdateName();
    }

    void UpdateSprite()
    {
        img.sprite = sprites[characterIndex];
    }

    void UpdateName()
    {
        characterText.text = characters[characterIndex].characterName;
    }

    void UpdatePlayerInfo()
    {
        DataManager.Instance.data.players[playerIndex].characterIndex = characterIndex;
    }

    void CheckIndexRange()
    {
        characterIndex = characterIndex % sprites.Length;
        if (characterIndex < 0)
        {
            characterIndex *= -1;
        }
    }

    bool CheckUnlocked()
    {
        return characters[characterIndex].unlocked;
    }


    public void GoLeft()
    {
        characterIndex -= 1;
        CheckIndexRange();

        if(!CheckUnlocked())
        {
            GoLeft();
        }

        UpdateSprite();
        UpdateName();
        UpdatePlayerInfo();
    }

    public void GoRight()
    {
        characterIndex += 1;
        CheckIndexRange();

        if(!CheckUnlocked())
        {
            GoRight();
        }

        UpdateSprite();  
        UpdateName();      
        UpdatePlayerInfo();
    }

}
