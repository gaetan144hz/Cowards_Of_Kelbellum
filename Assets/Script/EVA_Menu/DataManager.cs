using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DataManager : MonoBehaviour
{

    public static DataManager Instance { get; private set; }

    private string saveDir = @"\saves";
    public SaveData data = new SaveData();

    private void Awake() 
    {
        if (Instance != null)
        {
            Debug.Log("SINGLETON - Trying to create another singleton!");
        }
        else 
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }

//SAVE
    public void SaveJson(SaveData targetData, int saveIndex)
    {
        // Automatic Data Change
        OnSaveInfo(data, saveIndex);

        string dataString = JsonUtility.ToJson(targetData);
        File.WriteAllText(Application.persistentDataPath + saveDir + @"\save" + saveIndex + ".json", dataString);

        Debug.Log("DataManager -- " + dataString);
        Debug.Log("DataManager -- Saved!");
    }
//LOAD
    public void LoadJson(SaveData targetData, int saveIndex)
    {
        string dataString = File.ReadAllText(Application.persistentDataPath + saveDir + @"\save" + saveIndex + ".json");
        JsonUtility.FromJsonOverwrite(dataString, targetData);

        Debug.Log("DataManager -- " + dataString);
        Debug.Log("DataManager -- Loaded!");
    }

//AUTOMATIC DATA CHANGE
    public void OnSaveInfo(SaveData targetData, int saveIndex)
    {
        targetData.saveNumber = saveIndex;

        DateTime now = DateTime.Now;
        targetData.saveDate = "" + now;

        targetData.charactersData = CreateCharacters();
    }

    public List<Character> CreateCharacters()
    {
        List<Character> allChar = new List<Character>();

        Character Boldric = new Character();
        Boldric.characterName = "Boldric";
        Boldric.unlocked = true;
        Boldric.xp = 0;
        allChar.Add(Boldric);

        Character Groff = new Character();
        Groff.characterName = "Groff";
        Groff.unlocked = true;
        Groff.xp = 0;
        allChar.Add(Groff);

        Character Elas = new Character();
        Elas.characterName = "Elas";
        Elas.unlocked = true;
        Elas.xp = 0;   
        allChar.Add(Elas);  

        return allChar;   
    }


    //GETS
    public List<Player> GetPlayers()
    {
        return data.players;
    }

    public List<Character> GetCharacters()
    {
        return data.charactersData;
    }

}


//DATA TYPES AND CLASSES

[System.Serializable]
public class SaveData
{
    public int saveNumber = -1;
    public string saveDate;

    public List<Player> players = new List<Player>();
    public List<Character> charactersData = new List<Character>();

    
    //CLEAR PLAYER DATA FOR NEW GAME
    public void ClearPlayers()
    {
        players.Clear();
    }

    //CREATE NEW PLAYER
    public void NewPLayer(int playerIdx, string playerStr, int controlID, InputDevice id)
    {
        Player newPlayer = new Player();
        newPlayer.playerIndex = playerIdx; 
        newPlayer.playerString = playerStr; 
        newPlayer.controllerID = controlID;
        newPlayer.id = id;

        players.Add(newPlayer); 
    }
}

[System.Serializable]
public class Player
{
    public int playerIndex;
    public string playerString;
    public int controllerID;
    public InputDevice id;
    public int characterIndex;
}

[System.Serializable]
public class Character
{
    public string characterName;
    public bool unlocked = false;
    public int xp = 0;
}
