using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // player movement values
    public float PlayerMoveSpeed;
    public float PlayerJumpHeight;
    public bool CanJump;

    // player movement direction
    [SerializeField] private Vector2 MovementDirection;

    // players rigidbody
    private Rigidbody2D rb;

    // player character values
    public string ActiveCharater;
    private bool CanDoubleJump = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        MovementDirection = value.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            if (CanJump == false) { return; }
            if (rb.linearVelocityY <= -0.5f) { return; }
            // Get player's starting jump height
            // Make player and background layer not interact
            rb.linearVelocityY = PlayerJumpHeight;
            CanJump = false;

            // When landing and player has fallen with gravity if player's y value = or is close to their starting jump height
            // Make player layer and background be able to interact
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX = MovementDirection.x * PlayerMoveSpeed;

        // if(this.transform.y >)
        rb.linearVelocityY = MovementDirection.y * PlayerMoveSpeed;
    }
}
