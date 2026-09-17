using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] PlayerMovement PM;

    public float GroundCheckRadius;
    public LayerMask GroundMask;
    public Transform GroundCheckObject;
    public Collider2D isGrounded;


    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheckObject.position, GroundCheckRadius, GroundMask);

        if(isGrounded == false) { PM.CanJump = false; return; }
        if(isGrounded == true) { PM.CanJump = true; }
    }
}
