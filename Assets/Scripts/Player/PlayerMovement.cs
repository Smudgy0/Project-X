using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // player movement values
    public float PlayerMoveSpeed;
    public float PlayerJumpHeight;
    public float playerJumpOffset;

    // Stored Variables
    public float myHeight;

    // Toggle Variables
    public bool isJumping;


    // player movement direction
    [SerializeField] private Vector2 MovementDirection;

    // players rigidbody/colliders
    private Rigidbody2D rb;

    // Mask
    public GameObject backGroundcollider;

    // player character values
    public CharacterInfo ActiveCharater;

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

            // setjumping to true and enable gravity
            isJumping = true;
            // Get player's starting jump height
            myHeight = this.transform.position.y;

            // Make player and background layer not interact
            Physics2D.IgnoreLayerCollision(6, 7, true);
            print($"{Physics2D.GetIgnoreLayerCollision(6, 7)} 6 & 7 Should NOT be able to interact");

            Invoke("SetOffset", 0.02f);

            rb.gravityScale = 1;
            rb.linearVelocityY = PlayerJumpHeight;
        }
    }

    // Sets the landing offset of the y value while in the air. Fixes landing Y value dropping too far
    void SetOffset()
    {
        playerJumpOffset = 0.1f;
    }

    private void FixedUpdate()
    {
        if (!isJumping)
        {
            rb.linearVelocity = MovementDirection * PlayerMoveSpeed;
        }

        if (isJumping)
        {
            if (this.transform.position.y < myHeight + playerJumpOffset || rb.linearVelocityY == 0)
            {

                // Make player layer and background be able to interact
                Physics2D.IgnoreLayerCollision(6, 7, false);
                print($"{Physics2D.GetIgnoreLayerCollision(6, 7)} 6 & 7 Should be able to interact");

                rb.linearVelocityY = 0;
                rb.gravityScale = 0;
                isJumping = false;
                playerJumpOffset = 0;
                transform.position = new Vector2(transform.position.x, myHeight);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Tele")
        {
            Teleporter teleporter = collision.GetComponent<Teleporter>(); 
            this.gameObject.transform.position = teleporter.SendPlayerTo.position + (Vector3)teleporter.Offset;
        }
    }
}
