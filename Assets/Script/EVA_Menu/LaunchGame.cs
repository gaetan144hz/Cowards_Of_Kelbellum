using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchGame : MonoBehaviour
{

    public void ToGame()
    {
        DataManager.Instance.SaveJson(DataManager.Instance.data, DataManager.Instance.data.saveNumber);
        SceneManager.LoadScene("1_SCENE", LoadSceneMode.Single);
    }

}
