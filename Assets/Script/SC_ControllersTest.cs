using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class SC_ControllersTest : MonoBehaviour
{

    public Controllers playerInput;
    private Vector2 moveInput;
    private Rigidbody rb;
    [SerializeField] private float speed;
    
    void Start()
    {
        playerInput = new Controllers();
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    #region Movement

    public void OnMove(InputValue value)
    {
        if (value.isPressed)
        {
            Debug.Log("$$$$$$$");
            moveInput = value.Get<Vector2>();
            rb.velocity = moveInput * speed;
        }
    }

    #endregion
}
