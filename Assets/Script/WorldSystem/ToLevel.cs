using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevel : MonoBehaviour
{

    public string sceneName;
    public int spawnerIndex;

    private int playerCount;
    public int playerVotes = 0;

    void Start()
    {
        playerCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log(playerCount);

        playerVotes = 0;
    }

    void SaveLevel()
    {
        DataManager.Instance.data.SaveLevelData(sceneName, spawnerIndex);
    }

    void AddVote()
    {
        playerVotes += 1;
    }

    void ToScene()
    {
        DataManager.Instance.data.spawnIndex = spawnerIndex;
        DataManager.Instance.data.areaName = sceneName;

        //DataManager.Instance.SaveJson(DataManager.Instance.data, DataManager.Instance.data.saveNumber);

        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerObjects")
        {
            AddVote();
            if (playerCount-playerVotes <= 1)
            {
                ToScene();
            }
        }
    }
}
