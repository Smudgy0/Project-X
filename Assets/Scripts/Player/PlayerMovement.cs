using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // player movement values
    public float PlayerMoveSpeed;
    public int PlayerJumpHeight;
    public bool CanJump;
    public bool isJumping;
    public float myHeight;

    // player movement direction
    [SerializeField] private Vector2 MovementDirection;

    // players rigidbody/colliders
    private Rigidbody2D rb;
    public BoxCollider2D MyCollider;
    public CompositeCollider2D CC;

    // player character values
    public string ActiveCharater;
    private bool CanDoubleJump = false;

    // Mask
    public GameObject backGroundcollider;

    void Start()
    {
        myHeight = this.transform.position.y;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        MovementDirection = value.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            if (isJumping == true) { return; }
            if (rb.linearVelocityY <= -0.5f) { return; }
            isJumping = true;
            rb.gravityScale = 1;
            // Get player's starting jump height
            myHeight = this.transform.position.y;
            // Make player and background layer not interact
            Physics2D.IgnoreLayerCollision(6, 7, true);
            rb.AddForce(Vector2.up * PlayerJumpHeight, ForceMode2D.Impulse);

            // When landing and player has fallen with gravity if player's y value = or is close to their starting jump height
        }
    }

    private void FixedUpdate()
    {
        // if(this.transform.y >)
        if (!isJumping)
        {
            rb.linearVelocityX = MovementDirection.x * PlayerMoveSpeed;
            rb.linearVelocityY = MovementDirection.y * PlayerMoveSpeed;
        }
        //if(this.transform.position.y < myHeight && isJumping)
        //{
        //    rb.linearVelocityY = MovementDirection.y - rb.mass;
        //}

        if (this.transform.position.y < myHeight)
        {
            // Make player layer and background be able to interact
            Physics2D.IgnoreLayerCollision(6, 7, false);
            isJumping = false;
            rb.gravityScale = 0;
        }
    }
}
