using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

[RequireComponent(typeof(PlayerInput))]
public class JoinLobby : MonoBehaviour
{

    public GameObject[] autoLayout;

    public GameObject indexUI;
    private TextMeshProUGUI indexText;
    public GameObject controllerUI;
    private TextMeshProUGUI controllerText;

    private PlayerInput playerInput;
 
    private GameObject datam;
    private DataManager datam_manager;
 
    private void Start() 
    {

        playerInput = this.GetComponent<PlayerInput>();
        
        if (shouldBeAlive())
        {
            transform.SetParent(autoLayout[0].transform);
            EditCard();

            datam = GameObject.Find("Data Manager");
            datam_manager = datam.GetComponent<DataManager>();

            SavePlayer();
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    private bool shouldBeAlive()
    {
        autoLayout = GameObject.FindGameObjectsWithTag("Respawn");
        foreach (GameObject g in autoLayout)
        {
            return true;
        }
        return false;
    }

    void EditCard()
    {
        indexText = indexUI.GetComponent<TextMeshProUGUI>();
        controllerText = controllerUI.GetComponent<TextMeshProUGUI>();

        indexText.text = "Player " + (playerInput.playerIndex + 1);
        controllerText.text = playerInput.currentControlScheme + "\nID: " + (playerInput.devices[0].deviceId);
    }

    public void SavePlayer()
    {
        datam_manager.data.NewPLayer(playerInput.playerIndex, playerInput.currentControlScheme, playerInput.devices[0].deviceId, playerInput.devices[0]);
    }

}
