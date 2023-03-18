using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.InputSystem;
using Unity.Netcode;

public class CharacterController : NetworkBehaviour
{


    [Header("Movement")]
    
    public float speed;
    public Vector2 move;

    public float dashStrenght;
    public float dashesLeft;
    public float dashAmount;
    public float dashCooldown;

    private float lastDashRecoveryTime = 0f;
    private float currentTime = 0f;

    [Header("Animation")]

    public Animator animator;

    int isRunningHash;

    public PlayerInput input;

    public Vector2 currentMovement;
    public bool movementPressed;

    [Header("Attack System")]

    public float attackSpeed;
    public float comboSpeed;
    public int comboCount = 0;
    
    int comboCountHash;

    public VisualEffect slashEffect1;
    public VisualEffect slashEffect2;
    public VisualEffect slashEffect3;

    private float lastAttackTime = 0f;



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
        dashesLeft = dashAmount;
        animator = GetComponentInChildren<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
        comboCountHash = Animator.StringToHash("comboCount");
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsOwner) return;
        currentTime = Time.time;

        handleAnimation();
        handleMovement();
        handlePrimary();
    }

    void handleMovement()
    {
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = new Vector3(currentMovement.x, 0, currentMovement.y);
        Vector3 positionToLookAt = currentPosition + newPosition;

        if(comboCount == 0) 
        {
            transform.Translate(newPosition * speed * Time.deltaTime, Space.World);
            transform.LookAt(positionToLookAt);
        }


        if((currentTime - lastDashRecoveryTime)>dashCooldown && dashesLeft != dashAmount)
        {
            dashesLeft += 1;
            lastDashRecoveryTime = currentTime;
        }
        if(input.Player.Dash.triggered && movementPressed && dashesLeft > 0)
        {
            transform.Translate(newPosition * dashStrenght * 100 * Time.deltaTime, Space.World);
            dashesLeft -= 1;
            if(lastDashRecoveryTime == 0 | (currentTime - lastDashRecoveryTime)>dashCooldown)
            {
                lastDashRecoveryTime = Time.time;
            }
        }
    }

    void handleAnimation() 
    {
        bool isRunning = animator.GetBool(isRunningHash);

        if(movementPressed && !isRunning) {
            animator.SetBool(isRunningHash, true);
        }
        if(!movementPressed && isRunning) {
            animator.SetBool(isRunningHash, false);
        }
    }

    void handlePrimary()
    {
        float differenceLastAttackTime = currentTime - lastAttackTime;
        if(differenceLastAttackTime > comboSpeed && comboCount != 0)
        {
            comboCount = 0;
            
            animator.SetInteger(comboCountHash,comboCount);
        }
        if(input.Player.Primary.triggered && differenceLastAttackTime > attackSpeed)
        {
            if(differenceLastAttackTime < comboSpeed && comboCount != 3)
            {
                comboCount += 1;
            }
            else
            {
                comboCount = 1;
            }
            
            if(comboCount == 1)
            {
                slashEffect1.SendEvent("PlaySlash");
            }
            if(comboCount == 2)
            {
                slashEffect2.SendEvent("PlaySlash");
            }
            if(comboCount == 3)
            {
                slashEffect3.SendEvent("PlaySlash");
            }

            animator.SetInteger(comboCountHash,comboCount);
            lastAttackTime = currentTime;
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
