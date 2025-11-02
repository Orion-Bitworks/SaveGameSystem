using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    InputManager inputManager;
    
    [SerializeField] float horizontalSpeed;
    [SerializeField][Range(1f, 2f)] float sprintMultiplier;
    [SerializeField] float rotationSpeed;
    [SerializeField] AnimationCurve accelerationCurve;
    [SerializeField] float jumpForce = 14f;

    private bool isMoving;
    private Rigidbody rb;
    private Vector3 movementDirection;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;

    private bool isGrounded;
    private float horizontalXMovement, horizontalZMovement;
    private float timer = 0;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        inputManager = InputManager.instance;
    }
    private void Update()
    {
        isGrounded = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer).Length > 0;
    }

    void FixedUpdate()
    {
        OnMovement();
        //OnJump();
    }

    void OnMovement()
    {
        horizontalXMovement = inputManager.horizontalX_ia.ReadValue<float>();
        horizontalZMovement = inputManager.horizontalZ_ia.ReadValue<float>();

        Vector3 movementInput = new Vector3(horizontalXMovement, 0f, horizontalZMovement);
        isMoving = movementInput.sqrMagnitude > 0.01f;

        movementDirection = movementInput.normalized * horizontalSpeed;
        movementDirection.y = rb.velocity.y;

        if (isMoving) // Si la velocidad no es 0, actualiza la rotacion
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(movementDirection.x, 0f, movementDirection.z)), Time.deltaTime * rotationSpeed); // Mirar de quitar el delta time
        }
        
        if (movementDirection == Vector3.zero)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer += Time.deltaTime;
        }

        timer = Mathf.Clamp(timer, 0, accelerationCurve.length); 

        rb.velocity = movementDirection;

        // Multiplica la velocidad si el boton de sprint esta presionado
        if (inputManager.sprint_ia.IsPressed())
        {
            rb.velocity *= sprintMultiplier;
        }
    }

    /*void OnJump()
    {
        if (inputManager.jump_ia.IsPressed() && isGrounded) {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
        }
    }*/
}
