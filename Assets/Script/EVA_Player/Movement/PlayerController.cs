using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{

    [Header("Player Movement")]
    [SerializeField]
    private float playerSpeed = 5.0f;
    [SerializeField]
    private float gravityValue = -9.81f; 

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    public Vector2 movementInput = Vector2.zero;
    public Vector2 aimInput = Vector2.zero;

    Camera cam;
    Vector2 screenSize;
    Vector2 viewportSize;

    //INIT
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        cam = Camera.main.GetComponent<Camera>();
        screenSize = new Vector2(Screen.width, Screen.height);
        viewportSize = new Vector2(480, 270);
    }


    //INPUT GET
    public void OnMove(InputAction.CallbackContext context) 
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        aimInput = context.ReadValue<Vector2>();
        if (context.control.device.description.deviceClass == "Mouse") {
            var posToScreen = cam.WorldToScreenPoint(this.gameObject.transform.position);

            posToScreen = posToScreen / viewportSize;        
            aimInput = aimInput / screenSize;
            
            aimInput = aimInput - new Vector2(posToScreen.x, posToScreen.y);
            aimInput.Normalize();
        }
    }


    //MOVEMENT
    private void HandleMovement() 
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void HandleAim()
    {
        if (aimInput != Vector2.zero)
        {
            Vector3 aimVector = new Vector3(aimInput.x, 0, aimInput.y);
            gameObject.transform.forward = aimVector;
        }
    }

    void Update()
    {
        HandleMovement();
        HandleAim();
    }
}