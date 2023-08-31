using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    public GameObject avatarGameObject;
    public PlayerController playerController;
    public Animator animator;


    void Start()
    {
        animator = avatarGameObject.GetComponent<Animator>();
    }

    void Update()
    {
        checkState();
    }

    public void checkState()
    {
        if (playerController.movementInput != Vector2.zero)
        {
            animator.SetBool("isRunning", true);
        }
        else 
        {
            animator.SetBool("isRunning", false);
        }
    }

}
