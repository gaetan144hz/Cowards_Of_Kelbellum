using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnPlayer : MonoBehaviour
{

    public GameObject playerPrefab;
    public PlayerData[] playerData;

    public bool isCombatLevel = false; 

    // Start is called before the first frame update
    void Start()
    {
        if (!isCombatLevel)
        {
            SpawnPlayers();
        }
    }

    public void SpawnPlayers()
    {
        var players = DataManager.Instance.GetPlayers();
        foreach(var player in players)
        {
            var spawned = PlayerInput.Instantiate(playerPrefab, player.index, player.controlScheme, -1, player.device);
            
            spawned.SendMessage("LoadPlayerData", playerData[player.characterIndex]);

            spawned.SendMessage("SetDisplay", isCombatLevel);

            spawned.transform.position = transform.GetChild(DataManager.Instance.data.spawnIndex).position + new Vector3(player.index * 2 , 0, 0);
        }
    }
}
