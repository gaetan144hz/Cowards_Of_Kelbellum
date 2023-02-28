using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public Animator animator;

    int isRunningHash;

    PlayerInput input;

    Vector2 currentMovement;
    bool movementPressed;

    void Awake() 
    {
        input = new PlayerInput();

        input.Player.Movement.performed += ctx => {
            currentMovement = ctx.ReadValue<Vector2>();
            movementPressed = currentMovement.x != 0 || currentMovement.y != 0;
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();
        handleRotation();
    }

    void handleRotation()
    {
        Vector3 currentPosition = transform.position;

        Vector3 newPosition = new Vector3(currentMovement.x, 0, currentMovement.y);

        Vector3 positionToLookAt = currentPosition + newPosition;

        transform.LookAt(positionToLookAt);
    
    }

    void handleMovement() 
    {
        bool isRunning = animator.GetBool(isRunningHash);

        if (movementPressed && !isRunning) {
            animator.SetBool(isRunningHash, true);
        }
        
        if (!movementPressed && isRunning) {
            animator.SetBool(isRunningHash, false);
        }

    }

    void OnEnable() 
    {
        input.Player.Enable();
    }
    void OnDisable() 
    {
        input.Player.Disable();
    }
}
