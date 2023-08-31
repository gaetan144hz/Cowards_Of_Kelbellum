using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchGame : MonoBehaviour
{

    public void ToGame()
    {
        DataManager.Instance.SaveJson(DataManager.Instance.data, DataManager.Instance.data.saveNumber);

        DataManager.Instance.data.SaveLevelData(DataManager.Instance.data.areaName, 0);
        
        SceneManager.LoadScene(DataManager.Instance.data.areaName, LoadSceneMode.Single);

    }

}
