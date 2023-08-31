using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SaveManager : MonoBehaviour
{

    [Header("//Saves")]
    [Space(5)]
    private string saveDir = @"\saves";
    public int numberOfUsedSaves = -1;
    public int maxNumberOfSaves = 3;
    public string[] savesString;

    [Header("//Save Menu")]
    [Space(5)]
    public GameObject saveAutoLayout;
    public GameObject newSave;
    public GameObject saveTemplate;


    [Header("Data Manager")]
    public DataManager datam;
    public SaveData tempData;

    [Header("Menu Manager")]
    public MenuManager menuManager;

    void Start()
    {
        Debug.Log("Save Manager -- " + Application.persistentDataPath);
    }

    public void IntoSaveMenu()
    {

        if(!Directory.Exists(Application.persistentDataPath + saveDir))
        {
            Directory.CreateDirectory(Application.persistentDataPath + saveDir);
        }

        GetSaves();
        SaveMenuInitiate();
    }

    private void SaveMenuInitiate()
    {
        if (numberOfUsedSaves < maxNumberOfSaves) 
        {
            newSave.SetActive(true);
        }

        if (numberOfUsedSaves > 0)
        {

            int currentSave = 0;

            foreach(string singleSave in savesString)
            {
                GameObject saveTemplateChild = saveTemplate.transform.GetChild(0).gameObject;
                saveTemplateChild.GetComponent<TextMeshProUGUI>().text = "Save " + currentSave;
                
                saveTemplateChild = saveTemplate.transform.GetChild(1).gameObject;
                datam.LoadJson(tempData, currentSave);
                saveTemplateChild.GetComponent<TextMeshProUGUI>().text = "" + tempData.saveDate; 

                var newSaveButton = Instantiate(saveTemplate, saveTemplate.transform.position, Quaternion.identity);
                newSaveButton.transform.SetParent(saveAutoLayout.transform, true);
                newSaveButton.name = "" + currentSave;
                newSaveButton.SetActive(true);

                Button btn = newSaveButton.GetComponent<Button>();
                btn.onClick.AddListener(delegate {GoToNext(int.Parse(newSaveButton.name));});

                Debug.Log("Save Manager -- " + "Created save button " + currentSave);

                currentSave = currentSave + 1;
            }
        }
    }


    public void GetSaves()
    {
        savesString = Directory.GetFiles(Application.persistentDataPath + saveDir, "*", SearchOption.TopDirectoryOnly);
        numberOfUsedSaves = savesString.Length;
    }

    public void CreateSave()
    {
        datam.SaveJson(datam.data, numberOfUsedSaves);
        GoToNext(numberOfUsedSaves);
    }

    public void ReadSave(int saveIndex)
    {
        datam.LoadJson(datam.data, saveIndex);
        datam.data.ClearPlayers();
    }




    public void GoToNext(int saveIndex)
    {
        ReadSave(saveIndex);
        menuManager.ToCharacterSelection();

    }

}