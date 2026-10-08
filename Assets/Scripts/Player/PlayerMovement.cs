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
    public bool isDead;


    // player movement direction
    [SerializeField] private Vector2 MovementDirection;

    // players rigidbody/colliders
    public Rigidbody2D rb;

    // Mask
    public GameObject backGroundcollider;

    // player character values
    public CharacterInfo ActiveCharater;
    public CharacterInfo[] PlayableCharacters;
    public int CharacterSelected = 0;

    // GroundChecker
    public float groundCheckRadius;
    public Transform groundCheckObject;
    public LayerMask groundMask;
    public Collider2D isGrounded;
    void Start()
    {
        myHeight = this.transform.position.y;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        PlayerMoveSpeed = PlayableCharacters[CharacterSelected].thisCharacterMoveSpeed;
        PlayerJumpHeight = PlayableCharacters[CharacterSelected].thisCharacterJumpSpeed;

        isDead = false;
    }

    public void OnSwapCharacter(InputAction.CallbackContext value)
    {
        if (isDead == true) { return; }
        if (value.performed)
        {
            if (CharacterSelected == PlayableCharacters.Length) { CharacterSelected = 0; }
            ActiveCharater = PlayableCharacters[CharacterSelected];
            GetCharStats(PlayableCharacters[CharacterSelected]);
            CharacterSelected += 1;
        }
    }

    public void GetCharStats(CharacterInfo CharInfo)
    {
        PlayerMoveSpeed = CharInfo.thisCharacterMoveSpeed;
        PlayerJumpHeight = CharInfo.thisCharacterJumpSpeed;
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        if (isDead == true) { return; }
        MovementDirection = value.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext value)
    {
        if (isDead == true) { return; }
        if (value.performed)
        {
            if (isJumping == true || isGrounded == false) { return; }

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

    private void Update()
    {
        if (isDead == true) { return; }
        isGrounded = Physics2D.OverlapCircle(groundCheckObject.position, groundCheckRadius, groundMask);
    }

    private void FixedUpdate()
    {
        if (isDead == true) { return; }
        if (!isJumping)
        {

            if(isGrounded == false)
            {
                rb.gravityScale = 1;
                return;
            }
            else
            {
                rb.gravityScale = 0;
                rb.linearVelocity = MovementDirection * PlayerMoveSpeed;
                return;
            }
        }

        if (isJumping)
        {
            rb.linearVelocityX = MovementDirection.x * PlayerMoveSpeed;
            if (this.transform.position.y < myHeight + playerJumpOffset || rb.linearVelocityY == 0)
            {
                if(isGrounded == false)
                {
                    return;
                }
                /*if(when getting to the original landing height, the collider isn't hit on the ground)
                 * use physics to make the player start falling until their collider hits the ground again
                */
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
            this.gameObject.transform.position = teleporter.SendPlayerTo.position;
            teleporter.SwitchCameraView(this.gameObject.transform);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheckObject.position, groundCheckRadius);
    }
}
