using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    private string saveDir = @"\saves";
    public SaveData data = new SaveData();

    void Start() 
    {

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
}

[System.Serializable]
public class Player
{
    public int playerIndex;
    public string playerString;
    public int controllerID;

}

[System.Serializable]
public class Character
{
    public string characterName;
    public bool unlocked = false;
    public int xp = 0;
}
