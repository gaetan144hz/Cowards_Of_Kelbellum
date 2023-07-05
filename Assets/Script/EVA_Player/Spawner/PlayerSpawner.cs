using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawner : MonoBehaviour
{

    public GameObject[] playerPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        var players = DataManager.Instance.GetPlayers();
        foreach(var player in players)
        {
            var spawned = PlayerInput.Instantiate(playerPrefabs[player.characterIndex], player.playerIndex, player.playerString, -1, player.id);
            spawned.transform.position = this.gameObject.transform.position + new Vector3(player.playerIndex * 2 , 0, 0);
        }
    }
    
}
