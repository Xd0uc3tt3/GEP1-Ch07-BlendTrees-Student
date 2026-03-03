using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 moveInput;

    private Rigidbody2D playerRb;

    public Animator animator;

    private Vector2 lastMove = Vector2.down;


    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        if (playerRb == null) Debug.LogError("Rigidbody2D component not found on the player object.");

        animator = GetComponentInChildren<Animator>();

    }


    private void Update()
    {
        UpdateAnimatorParameters();
    }

    private void FixedUpdate()
    {
        HandlePlayerMovement();
    }

    private void LateUpdate()
    {

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void HandlePlayerMovement()
    {
        playerRb.MovePosition(playerRb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    private void UpdateAnimatorParameters()
    {
        bool isMoving = moveInput.sqrMagnitude > 0.01f;

        animator.SetBool("IsMoving", isMoving);
        animator.SetFloat("MoveInputX", moveInput.x);
        animator.SetFloat("MoveInputY", moveInput.y);

        if (isMoving)
        {
            lastMove = moveInput.normalized;
            animator.SetFloat("LastMoveX", lastMove.x);
            animator.SetFloat("LastMoveY", lastMove.y);
        }
    }




}
















